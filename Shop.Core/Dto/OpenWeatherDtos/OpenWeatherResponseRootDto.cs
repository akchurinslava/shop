using System;
using System.Text.Json.Serialization;
using Shop.Core.Dto.OpenWeatherDtos;

namespace Shop.Core.Dto
{
    public class OpenWeatherResponseRootDto
    {
        [JsonPropertyName("coord")]
        public Coord Coord { get; set; }

        [JsonPropertyName("weather")]
        public List<Weather> Weather { get; set; }

        [JsonPropertyName("base")]
        public string Base { get; set; }

        [JsonPropertyName("main")]
        public Main Main { get; set; }

        [JsonPropertyName("visibility")]
        public int Visibility { get; set; }

        [JsonPropertyName("wind")]
        public Wind Wind { get; set; }

        [JsonPropertyName("clouds")]
        public Clouds Clouds { get; set; }

        [JsonPropertyName("rain")]
        public Rain Rain { get; set; }

        [JsonPropertyName("snow")]
        public Snow Snow { get; set; }

        [JsonPropertyName("dt")]
        public int Dt { get; set; }

        [JsonPropertyName("sys")]
        public Sys Sys { get; set; }

        [JsonPropertyName("time_zone")]
        public int TimeZone { get; set; }

        [JsonPropertyName("time_zone_id")]
        public int TimeZoneId { get; set; }

        [JsonPropertyName("time_zone_name")]
        public string Name { get; set; }

        [JsonPropertyName("time_zone_cod")]
        public int TimzeZoneCod { get; set; }


    }
}

