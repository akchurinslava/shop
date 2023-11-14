using System.Text.Json.Serialization;

namespace Shop.Core.Dto
{
    public class Clouds
    {
        [JsonPropertyName("all")]
        public int All { get; set; }
    }
}