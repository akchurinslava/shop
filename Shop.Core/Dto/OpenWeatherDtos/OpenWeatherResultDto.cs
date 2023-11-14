using System;
namespace Shop.Core.Dto
{
	public class OpenWeatherResultDto
	{
        public string City { get; set; }
        public double CoordLon { get; set; }
        public double CoordLat { get; set; }
        public int WeatherId { get; set; }
        public string WeatherMain { get; set; }
        public string WeatherDescription { get; set; }
        public string WeatherIcon { get; set; }
        public string Base { get; set; }
        public double MainTemp { get; set; }
        public double MainFeelsLike { get; set; }
        public double MainTempMin { get; set; }
        public double MainTempMax { get; set; }
        public int MainPressure { get; set; }
        public int MainHumidity { get; set; }
        public int Visibility { get; set; }
        public double WindSpeed { get; set; }
        public int WindDeg { get; set; }
        public int CloudsAll { get; set; }
        public int Dt { get; set; }
        public int SysType { get; set; }
        public int SysId { get; set; }
        public string SysCountry { get; set; }
        public int SysSunrise { get; set; }
        public int SysSunset { get; set; }
        public int TimeZone { get; set; }
        public int TimeZoneId { get; set; }
        public string TimeZoneName { get; set; }
        public int TimzeZoneCod { get; set; }



    }
}

