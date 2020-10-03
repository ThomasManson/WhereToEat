namespace WhereToEat.Models
{
    using System.Text.Json.Serialization;

    public class LatLng
    {
        [JsonPropertyName("lat")]
        public float Latitude { get; set; }
        
        [JsonPropertyName("lng")]
        public float Longitude { get; set; }
    }
}
