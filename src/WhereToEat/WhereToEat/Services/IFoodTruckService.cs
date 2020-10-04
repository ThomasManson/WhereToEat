using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WhereToEat.Models;

namespace WhereToEat.Services
{
    public interface IFoodTruckService
    {
        public Task<IEnumerable<FoodTruck>> GetFoodTrucksWithinAreaAsync(Position northwest, Position southeast);
    }
}
