using System.Text.Json.Serialization;

namespace Shop.Core.Dto
{
    public class Wind
    {
        [JsonPropertyName("speed")]
        public double Speed { get; set; }
        [JsonPropertyName("deg")]
        public int Deg { get; set; }
        [JsonPropertyName("gust")]
        public int Gust { get; set; }
    }
}