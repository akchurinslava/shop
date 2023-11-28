using System;
using Microsoft.AspNetCore.Mvc;
using Shop.Core.Dto.AccuWeatherDtos;
using Shop.Core.Dto.CocktailsDtos;
using Shop.Core.ServiceInterface;
using Shop.Models.AccuWeather;
using Shop.Models.Cocktails;

namespace Shop.Controllers
{
	public class AccuWeatherController : Controller
	{
        private readonly IAccuWeatherServices _accuWeatherServices;

        public AccuWeatherController(IAccuWeatherServices accuWeatherServices)
        {
            _accuWeatherServices = accuWeatherServices;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchCity(SearchAccuWeatherViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("CityResult", "AccuWeather", new { city = model.CityName });//1 - action, 2 - controller name
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult CityResult(string city)
        {
            AccuWeatherResultDto dto = new();
            dto.City = city;

            _accuWeatherServices.AccuWeatherResult(dto);
            AccuWeatherViewModel vm = new();


            vm.AccuCitysKey = dto.AccuCitysKey;
            vm.City = dto.City;
            vm.HeadlinesEffectiveDate = dto.HeadlinesEffectiveDate;
            vm.HeadlinesEffectiveEpochDate = dto.HeadlinesEffectiveEpochDate;
            vm.HeadlinesSeverity = dto.HeadlinesSeverity;
            vm.HeadlinesText = dto.HeadlinesText;
            vm.HeadlinesCategory = dto.HeadlinesCategory;
            vm.HeadlinesEndDate = dto.HeadlinesEndDate;
            vm.HeadlinesEndEpochDate = dto.HeadlinesEndEpochDate;
            vm.HeadlinesMobileLink = dto.HeadlinesMobileLink;
            vm.HeadlinesLink = dto.HeadlinesLink;
            vm.DailyForecastDate = dto.DailyForecastDate;
            vm.DailyForecastEpochDate = dto.DailyForecastEpochDate;
            vm.DailyForecastTemperaturesMinimumsValue = dto.DailyForecastTemperaturesMinimumsValue;
            vm.DailyForecastTemperaturesMinimumsUnit = dto.DailyForecastTemperaturesMinimumsUnit;
            vm.DailyForecastTemperaturesMinimumsUnitType = dto.DailyForecastTemperaturesMinimumsUnitType;
            vm.DailyForecastTemperaturesMaximumsValue = dto.DailyForecastTemperaturesMaximumsValue;
            vm.DailyForecastTemperaturesMaximumsUnit = dto.DailyForecastTemperaturesMaximumsUnit;
            vm.DailyForecastTemperaturesMaximumsUnitType = dto.DailyForecastTemperaturesMaximumsUnitType;
            vm.DailyForecastDaysIcon = dto.DailyForecastDaysIcon;
            vm.DailyForecastDaysIconPhrase = dto.DailyForecastDaysIconPhrase;
            vm.DailyForecastDaysHasPrecipitation = dto.DailyForecastDaysHasPrecipitation;
            vm.DailyForecastDaysPrecipitationType = dto.DailyForecastDaysPrecipitationType;
            vm.DailyForecastDaysPrecipitationIntensity = dto.DailyForecastDaysPrecipitationIntensity;
            vm.DailyForecastNightsIcon = dto.DailyForecastNightsIcon;
            vm.DailyForecastNightsIconPhrase = dto.DailyForecastNightsIconPhrase;
            vm.DailyForecastNightsHasPrecipitation = dto.DailyForecastNightsHasPrecipitation;
            vm.DailyForecastSources = dto.DailyForecastSources;
            vm.DailyForecastMobileLink = dto.DailyForecastMobileLink;
            vm.DailyForecastLink = dto.DailyForecastLink;





            return View(vm);

        }

    }
}

