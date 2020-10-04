namespace WhereToEat.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    using WhereToEat.Configuration;
    using WhereToEat.Models;

    public class FoodTruckService : IFoodTruckService
    {
        private readonly HttpClient httpClient;
        private readonly IOptionsSnapshot<AppConfigOptions> appConfigSnapshot;
        private readonly ILogger<FoodTruckService> logger;

        public FoodTruckService(HttpClient httpClient, IOptionsSnapshot<AppConfigOptions> appConfigSnapshot, ILogger<FoodTruckService> logger)
        {
            this.httpClient = httpClient;
            this.appConfigSnapshot = appConfigSnapshot;
            this.logger = logger;
        }

        public async Task<IEnumerable<FoodTruck>> GetFoodTrucksWithinAreaAsync(Position northwest, Position southeast)
        {
            try
            {
                this.logger.LogDebug("Starting GetFoodTrucksWithinAreaAsync: northwest: {northwest}, southeast: {southeast}", northwest, southeast);
                var url = ApiCatalog.GetFoodTrucksInArea(this.appConfigSnapshot.Value.FoodTruckUrl, northwest, southeast);
                var response = await this.httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var trucks = await JsonSerializer.DeserializeAsync<List<FoodTruck>>(await response.Content.ReadAsStreamAsync().ConfigureAwait(false)).ConfigureAwait(false);
                    return trucks;
                }
                else
                {
                    return new List<FoodTruck>();
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Error calling Open data source for food trucks");
                throw;
            }
        }
    }
}
