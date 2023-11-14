using Shop.Core.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using Shop.Models.OpenWeather;
using Shop.Core.Dto;

namespace Shop.Controllers
{


    public class OpenWeatherController : Controller
    {
        private readonly IWeatherForecastServices _weatherForecastServices;

        public OpenWeatherController(IWeatherForecastServices weatherForecastServices)
        {
            _weatherForecastServices = weatherForecastServices;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchCity(SearchCityViewModel model)
        {
            if (ModelState.IsValid) 
	        {
                return RedirectToAction("City", "OpenWeather", new { city = model.CityName });
	        }
            return View(model);
        }

        [HttpGet]
        public IActionResult City(string city)
	    {
            OpenWeatherResultDto dto = new();
            dto.City = city;

            _weatherForecastServices.OpenWeatherResult(dto);
            OpenWeatherViewModel vm = new();

            vm.City = dto.City;
            vm.CoordLon = dto.CoordLon;
            vm.CoordLat = dto.CoordLat;
            vm.WeatherId = dto.WeatherId;
            vm.WeatherMain = dto.WeatherMain;
            vm.WeatherDescription = dto.WeatherDescription;
            vm.WeatherIcon = dto.WeatherIcon;
            vm.Base = dto.Base;
            vm.MainTemp = dto.MainTemp;
            vm.MainFeelsLike = dto.MainFeelsLike;
            vm.MainTempMin = dto.MainTempMin;
            vm.MainTempMax = dto.MainTempMax;
            vm.MainPressure = dto.MainPressure;
            vm.MainHumidity = dto.MainHumidity;
            vm.Visibility = dto.Visibility;
            vm.WindSpeed = dto.WindSpeed;
            vm.WindDeg = dto.WindDeg;
            vm.CloudsAll = dto.CloudsAll;
            vm.Dt = dto.Dt;
            vm.SysType = dto.SysType;
            vm.SysId = dto.SysId;
            vm.SysCountry = dto.SysCountry;
            vm.SysSunrise = dto.SysSunrise;
            vm.SysSunset = dto.SysSunset;
            vm.TimeZone = dto.TimeZone;
            vm.TimeZoneId = dto.TimeZoneId;
            vm.TimeZoneName = dto.TimeZoneName;
            vm.TimzeZoneCod = dto.TimzeZoneCod;

            return View(vm);

	    }
    }
}
