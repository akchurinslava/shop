using System;
using System.Text.Json.Serialization;

namespace Shop.Core.Dto.AccuWeatherDtos
{
    public class AccuWeatherResponseRootDto2
    {
        [JsonPropertyName("Key")]
        public string Key { get; set; }

    }
}

