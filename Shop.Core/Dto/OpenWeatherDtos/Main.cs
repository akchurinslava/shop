using System.Text.Json.Serialization;

namespace Shop.Core.Dto
{
    public class Main
    {
        [JsonPropertyName("temp")]
        public double Temp { get; set; }
        [JsonPropertyName("feels_like")]
        public double Feels_Like { get; set; }
        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }
        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
        [JsonPropertyName("temp_min")]
        public double Temp_Min { get; set; }
        [JsonPropertyName("temp_max")]
        public double Temp_Max { get; set; }
        [JsonPropertyName("sea_level")]
        public double Sea_Level { get; set; }
        [JsonPropertyName("grnd_level")]
        public double Grnd_Level { get; set; }

    }
}