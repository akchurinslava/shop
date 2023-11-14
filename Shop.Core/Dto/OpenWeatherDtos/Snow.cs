using System.Text.Json.Serialization;

namespace Shop.Core.Dto
{
    public class Snow
    {
        [JsonPropertyName("snow1h")]
        public int Snow1H { get; set; }

        [JsonPropertyName("snow3h")]
        public int Snow3H { get; set; }
    }
}