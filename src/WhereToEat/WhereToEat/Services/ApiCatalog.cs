using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WhereToEat.Models;

namespace WhereToEat.Services
{
    public static class ApiCatalog
    {
        public static string GetFoodTrucksInArea(string baseUrl, Position northwest, Position southeast)
        {
            return $"{baseUrl}?$where=within_box(location,{northwest.Latitude},{northwest.Longitude},{southeast.Latitude},{southeast.Longitude})";
        }
    }
}
