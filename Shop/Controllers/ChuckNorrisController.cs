using System;
using Microsoft.AspNetCore.Mvc;
using Shop.Core.ChuckNorrisDtos;
using Shop.Core.ServiceInterface;
using Shop.Models.ChuckNorris;

namespace Shop.Controllers
{
	public class ChuckNorrisController : Controller
	{
		private readonly IChuckNorrisServices _chuckNorrisServices;

		public ChuckNorrisController(IChuckNorrisServices chuckNorrisServices)
		{
			_chuckNorrisServices = chuckNorrisServices;
		}

		public IActionResult Index() 
		{
			return View();
		}

		[HttpPost]
		public IActionResult GenerateJoke(ChuckNorrisJokeViewModel model)
		{
            //if (ModelState.IsValid)
            //{
            return RedirectToAction("Joke", "ChuckNorris", new { joke = model.JokeName });
            //}

            //return View(model);
        }

		[HttpGet]
		public IActionResult Joke(string joke)
		{

			ChuckNorrisResultDto dto = new();
			dto.Value = joke;

			_chuckNorrisServices.ChuckNorrisResult(dto);
			ChuckNorrisViewModel vm = new();

			vm.Categories = dto.Categories;
			vm.CreatedAt = dto.CreatedAt;
			vm.IconUrl = dto.IconUrl;
			vm.Id = dto.Id;
			vm.UpdatedAt = dto.UpdatedAt;
			vm.Url = dto.Url;
			vm.Value = dto.Value;

			return View(vm);
		}
	}
}

