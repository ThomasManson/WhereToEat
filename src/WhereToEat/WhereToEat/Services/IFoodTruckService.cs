namespace WhereToEat.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using WhereToEat.Models;

    public interface IFoodTruckService
    {
        public Task<IEnumerable<FoodTruck>> GetFoodTrucksWithinAreaAsync(Position northwest, Position southeast);
    }
}
