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

            vm.Key = dto.Key;
            vm.City = dto.City;
            vm.Minimum = (dto.Minimum - 32) * 5 / 9;
            vm.Maximum = (dto.Maximum - 32) * 5 / 9;
            vm.Link = dto.Link;
            vm.Text = dto.Text;
            vm.MobileLink = dto.MobileLink;
            vm.Date = dto.Date;
            //vm.Category = dto.Category;
            vm.DayIconPhrase = dto.DayIconPhrase;
            vm.NightIconPhrase = dto.NightIconPhrase;
            vm.Sources = dto.Sources;





            return View(vm);

        }

    }
}

