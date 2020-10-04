namespace WhereToEat.Services
{

    using WhereToEat.Models;

    public static class ApiCatalog
    {
        public static string GetFoodTrucksInArea(string baseUrl, Position northwest, Position southeast)
        {
            return $"{baseUrl}?$where=within_box(location,{northwest.Latitude},{northwest.Longitude},{southeast.Latitude},{southeast.Longitude})";
        }
    }
}
