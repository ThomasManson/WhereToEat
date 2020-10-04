namespace WhereToEat.Configuration
{
    /// <summary>
    /// Application settings that are loaded on start up
    /// </summary>
    public class AppConfigOptions
    {
        public const string AppConfig = "AppConfig";

        public string MapApiKey { get; set; }

        public string FoodTruckUrl { get; set; }
    }
}
