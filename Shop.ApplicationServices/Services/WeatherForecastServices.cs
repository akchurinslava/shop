
using System.Net;
using Nancy.Json;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;

namespace Shop.ApplicationServices.Services
{
	public class WeatherForecastServices : IWeatherForecastServices
	{
		public async Task<OpenWeatherResultDto> OpenWeatherResult(OpenWeatherResultDto dto) 
		{
			string idOpenWeather = "****";
			string url = $"https://api.openweathermap.org/data/2.5/weather?q={dto.City}&units=metric&&appid={idOpenWeather}";

			using (WebClient client = new WebClient())
			{
				string json = client.DownloadString(url);
				OpenWeatherResponseRootDto weatherResult = new JavaScriptSerializer().Deserialize<OpenWeatherResponseRootDto>(json);

				dto.City = weatherResult.Name;
				dto.MainTemp = weatherResult.Main.Temp;
				dto.MainFeelsLike = weatherResult.Main.Feels_Like;
				dto.MainHumidity = weatherResult.Main.Humidity;
				dto.MainPressure = weatherResult.Main.Pressure;
				dto.WindSpeed = weatherResult.Wind.Speed;
				dto.WeatherDescription = weatherResult.Weather[0].Description;
			}

			return dto;
		}
	}
}

