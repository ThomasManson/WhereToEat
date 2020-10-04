namespace WhereToEat.Models
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Simple class for a position based on Latitude and Longitude
    /// </summary>
    public class Position
    {
        public Position() 
        {
        }

        public Position(double latitude, double longitude)
        {
            this.Latitude= latitude;
            this.Longitude = longitude;
        }

        [JsonPropertyName("lat")]
        public double Latitude { get; set; }
        
        [JsonPropertyName("lng")]
        public double Longitude { get; set; }
    }
}
