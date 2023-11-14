using System.Text.Json.Serialization;

namespace Shop.Core.Dto
{
    public class Sys
    {
        [JsonPropertyName("sys_type")]
        public int SysType { get; set; }
        [JsonPropertyName("sys_id")]
        public int SysId { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("country")]
        public string SysCountry { get; set; }
        [JsonPropertyName("sunrise")]
        public int SysSunrise { get; set; }
        [JsonPropertyName("sunset")]
        public int SysSunset { get; set; }
    }
}