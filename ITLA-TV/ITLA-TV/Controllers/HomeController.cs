using System.Diagnostics;
using ITLA_TV.Core.Application.Interfaces.Services;
using ITLA_TV.Core.Application.ViewModels.Series;
using ITLA_TV.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITLA_TV.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISerieService serieService;

        private readonly IProducerService producerService;

        private readonly IGenderService genderService;
        public HomeController(ISerieService _serieService, IProducerService producerService, IGenderService genderService)
        {
            serieService = _serieService;
            this.producerService = producerService;
            this.genderService = genderService;
        }

        public async Task<IActionResult> Index(FilterSerieViewModel vm)
        {
            ViewBag.Producers = await producerService.GetAll();
            ViewBag.Genres = await genderService.GetAll();
            return View(await serieService.GetSeriesWithFilter(vm));
        }

        [HttpPost]
        public async Task<IActionResult> Order(int ordenar)
        {
            ViewBag.Producers = await producerService.GetAll();
            ViewBag.Genres = await genderService.GetAll();

            if (ordenar == 0)
            {

                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            var response = await serieService.Order(ordenar);
            return View("Index", response);
        }
    }
}
