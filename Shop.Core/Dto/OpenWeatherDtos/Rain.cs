using System.Text.Json.Serialization;

namespace Shop.Core.Dto
{
    public class Rain
    {
        [JsonPropertyName("rain1h")]
        public int Rain1H { get; set;}

        [JsonPropertyName("rain3h")]
        public int Rain3H { get; set; }
    }
}