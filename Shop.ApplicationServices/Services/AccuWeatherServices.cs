using System;
using Nancy.Json;
using Shop.Core.Dto;
using System.Net;
using Shop.Core.ServiceInterface;
using Shop.Core.Dto.AccuWeatherDtos;

namespace Shop.ApplicationServices.Services
{
	public class AccuWeatherServices : IAccuWeatherServices
	{
        public async Task<AccuWeatherResultDto> AccuWeatherResult(AccuWeatherResultDto dto)
        {
            string idAccuWeather = "Sq8rJIfcJEkHvyAMT8bYJjqxcQ34kXKb";
            string url = $"https://dataservice.accuweather.com/locations/v1/cities/search?apikey={idAccuWeather}={dto.City}";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                AccuWeatherResponseRootDto accuWeatherResult = new JavaScriptSerializer().Deserialize<AccuWeatherResponseRootDto>(json);

                
                dto.AccuCitysKey = accuWeatherResult.AccuCitys[0].Key;
                dto.City = accuWeatherResult.City;
                dto.HeadlinesEffectiveDate = accuWeatherResult.Headlines.EffectiveDate;
                dto.HeadlinesEffectiveEpochDate = accuWeatherResult.Headlines.EffectiveEpochDate;
            }
            //string abc = 

            string url2 = $"https://dataservice.accuweather.com/forecasts/v1/daily/1day/{dto.AccuCitysKey}?apikey={idAccuWeather}";
            using (WebClient client2 = new WebClient())
            {
                string json2 = client2.DownloadString(url2);
                AccuWeatherResponseRootDto accuWeatherResult2 = new JavaScriptSerializer().Deserialize<AccuWeatherResponseRootDto>(json2);

                
                dto.AccuCitysKey = accuWeatherResult2.AccuCitys[0].Key;
                dto.City = accuWeatherResult2.City;
                dto.HeadlinesEffectiveDate = accuWeatherResult2.Headlines.EffectiveDate;
                dto.HeadlinesEffectiveEpochDate = accuWeatherResult2.Headlines.EffectiveEpochDate;
                dto.HeadlinesSeverity = accuWeatherResult2.Headlines.Severity;
                dto.HeadlinesText = accuWeatherResult2.Headlines.Text;
                dto.HeadlinesCategory = accuWeatherResult2.Headlines.Category;
                dto.HeadlinesEndDate = accuWeatherResult2.Headlines.EndDate;
                dto.HeadlinesEndEpochDate = accuWeatherResult2.Headlines.EndEpochDate;
                dto.HeadlinesMobileLink = accuWeatherResult2.Headlines.MobileLink;
                dto.HeadlinesLink = accuWeatherResult2.Headlines.Link;
                dto.DailyForecastDate = accuWeatherResult2.DailyForecast[0].Date;
                dto.DailyForecastEpochDate = accuWeatherResult2.DailyForecast[0].EpochDate;
                dto.DailyForecastTemperaturesMinimumsValue = accuWeatherResult2.DailyForecast[0].Temperatures.Minimums.Value;
                dto.DailyForecastTemperaturesMinimumsUnit = accuWeatherResult2.DailyForecast[0].Temperatures.Minimums.Unit;
                dto.DailyForecastTemperaturesMinimumsUnitType = accuWeatherResult2.DailyForecast[0].Temperatures.Minimums.UnitType;
                dto.DailyForecastTemperaturesMaximumsValue = accuWeatherResult2.DailyForecast[0].Temperatures.Maximums.Value;
                dto.DailyForecastTemperaturesMaximumsUnit = accuWeatherResult2.DailyForecast[0].Temperatures.Maximums.Unit;
                dto.DailyForecastTemperaturesMaximumsUnitType = accuWeatherResult2.DailyForecast[0].Temperatures.Maximums.UnitType;
                dto.DailyForecastDaysIcon = accuWeatherResult2.DailyForecast[1].Days.Icon;
                dto.DailyForecastDaysIconPhrase = accuWeatherResult2.DailyForecast[1].Days.IconPhrase;
                dto.DailyForecastDaysHasPrecipitation = accuWeatherResult2.DailyForecast[1].Days.HasPrecipitation;
                dto.DailyForecastDaysPrecipitationType = accuWeatherResult2.DailyForecast[1].Days.PrecipitationType;
                dto.DailyForecastDaysPrecipitationIntensity = accuWeatherResult2.DailyForecast[1].Days.PrecipitationIntensity;
                dto.DailyForecastNightsIcon = accuWeatherResult2.DailyForecast[2].Nights.Icon;
                dto.DailyForecastNightsIconPhrase = accuWeatherResult2.DailyForecast[2].Nights.IconPhrase;
                dto.DailyForecastNightsHasPrecipitation = accuWeatherResult2.DailyForecast[2].Nights.HasPrecipitation;
                dto.DailyForecastSources = accuWeatherResult2.DailyForecast[3].Sources[0];
                dto.DailyForecastMobileLink = accuWeatherResult2.DailyForecast[4].MobileLink;
                dto.DailyForecastLink = accuWeatherResult2.DailyForecast[5].Link;
            }

            return dto;
        }
    }
}

