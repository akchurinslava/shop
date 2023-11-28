using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Shop.Core.Dto.AccuWeatherDtos
{
	public class AccuWeatherResponseRootDto
	{
        public List<AccuCity> AccuCitys { get; set; }

        public string City { get; set; }

        [JsonPropertyName("Headline")]
        public Headline Headlines { get; set; }

        [JsonPropertyName("DailyForecasts")]
        public List<DailyForecasts> DailyForecast { get; set; }
    }

    public class AccuCity
    {
            [JsonPropertyName("Key")]
            public string Key { get; set; }
    }

    public class DailyForecasts
    {
        [JsonProperty("Date")]
        public DateTime Date { get; set; }

        [JsonProperty("EpochDate")]
        public int EpochDate { get; set; }

        [JsonProperty("Temperature")]
        public Temperature Temperatures { get; set; }

        [JsonProperty("Day")]
        public Day Days { get; set; }

        [JsonProperty("Night")]
        public Night Nights { get; set; }

        [JsonProperty("Sources")]
        public List<string> Sources { get; set; }

        [JsonProperty("MobileLink")]
        public string MobileLink { get; set; }

        [JsonProperty("Link")]
        public string Link { get; set; }
    }

    public class Night
    {
        [JsonProperty("Icon")]
        public int Icon { get; set; }

        [JsonProperty("IconPhrase")]
        public string IconPhrase { get; set; }

        [JsonProperty("HasPrecipitation")]
        public bool HasPrecipitation { get; set; }
    }

    public class Day
    {
        [JsonProperty("Icon")]
        public int Icon { get; set; }

        [JsonProperty("IconPhrase")]
        public string IconPhrase { get; set; }

        [JsonProperty("HasPrecipitation")]
        public bool HasPrecipitation { get; set; }

        [JsonProperty("PrecipitationType")]
        public string PrecipitationType { get; set; }

        [JsonProperty("PrecipitationIntensity")]
        public string PrecipitationIntensity { get; set; }
    }

    public class Temperature
    {
        [JsonProperty("Minimum")]
        public Minimum Minimums { get; set; }

        [JsonProperty("Maximum")]
        public Maximum Maximums { get; set; }
    }

    public class Maximum
    {
        [JsonProperty("Value")]
        public int Value { get; set; }

        [JsonProperty("Unit")]
        public string Unit { get; set; }

        [JsonProperty("UnitType")]
        public int UnitType { get; set; }
    }

    public class Minimum
    {
        [JsonProperty("Value")]
        public int Value { get; set; }

        [JsonProperty("Unit")]
        public string Unit { get; set; }

        [JsonProperty("UnitType")]
        public int UnitType { get; set; }
    }

    public class Headline
    {
        [JsonProperty("EffectiveDate")]
        public DateTime EffectiveDate { get; set; }

        [JsonProperty("EffectiveEpochDate")]
        public int EffectiveEpochDate { get; set; }

        [JsonProperty("Severity")]
        public int Severity { get; set; }

        [JsonProperty("Text")]
        public string Text { get; set; }

        [JsonProperty("Category")]
        public string Category { get; set; }

        [JsonProperty("EndDate")]
        public DateTime EndDate { get; set; }

        [JsonProperty("EndEpochDate")]
        public int EndEpochDate { get; set; }

        [JsonProperty("MobileLink")]
        public string MobileLink { get; set; }

        [JsonProperty("Link")]
        public string Link { get; set; }
    }
}

