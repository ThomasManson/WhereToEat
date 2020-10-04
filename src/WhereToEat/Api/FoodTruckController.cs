// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WhereToEat.Api
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    using WhereToEat.Models;
    using WhereToEat.Services;

    [Route("api/[controller]")]
    [ApiController]
    public class FoodTruckController : ControllerBase
    {
        private readonly IFoodTruckService foodTruckService;
        private readonly ILogger<FoodTruckController> logger;

        public FoodTruckController(IFoodTruckService foodTruckService, ILogger<FoodTruckController> logger)
        {
            this.foodTruckService = foodTruckService;
            this.logger = logger;
        }

        // GET: api/<FoodTruckController>
        [HttpGet]
        public async Task<IEnumerable<FoodTruck>> GetAsync(
            [FromQuery] double northwestLatitude,
            [FromQuery] double northwestLongitude,
            [FromQuery] double southeastLatitude,
            [FromQuery] double southeastLongitude)
        {
            this.logger.LogDebug("Starting Get FoodTrucks. Parameters: northwestLatitude: {northwestLatitude}, northwestLongitude: {northwestLongitude}, southeastLatitude: {southeastLatitude}, southeastLongitude: {southeastLongitude}", northwestLatitude, northwestLongitude, southeastLatitude, southeastLongitude);

            var result = await this.foodTruckService.GetFoodTrucksWithinAreaAsync(new Position(northwestLatitude, northwestLongitude), new Position(southeastLatitude, southeastLongitude));

            this.logger.LogDebug("Result returned from FoodTruckService: ", result);
            return result;
        }

        // GET api/<FoodTruckController>/5
        /*[HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST api/<FoodTruckController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FoodTruckController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FoodTruckController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
