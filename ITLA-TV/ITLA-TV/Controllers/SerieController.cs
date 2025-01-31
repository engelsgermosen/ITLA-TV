using ITLA_TV.Core.Application.Interfaces.Services;
using ITLA_TV.Core.Application.ViewModels.Series;
using Microsoft.AspNetCore.Mvc;

namespace ITLA_TV.Controllers
{
    public class SerieController : Controller
    {
        private readonly ISerieService serieService;
        private readonly IProducerService producerService;
        private readonly IGenderService  genderService;


        public SerieController(ISerieService serieService, IProducerService producerService, IGenderService genderService )
        {
            this.serieService = serieService;
            this.producerService = producerService;
            this.genderService = genderService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await serieService.GetAll());
        }

        public async Task<IActionResult> VideoReproducer(int id)
        {
            return View(await serieService.GetByIdViewModel(id));
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.productoras = await producerService.GetAll();
            ViewBag.generos = await genderService.GetAll();


            return View("SaveSerie", new SaveSerieViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveSerieViewModel vm)
        {
            ViewBag.productoras = await producerService.GetAll();
            ViewBag.generos = await genderService.GetAll();

            if (!ModelState.IsValid)
            {
                return View("SaveSerie", vm);
            }
            await serieService.Add(vm);
            return RedirectToRoute(new { controller = "Serie", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {

            ViewBag.productoras = await producerService.GetAll();
            ViewBag.generos = await genderService.GetAll();

            return View("SaveSerie", await serieService.GetByIdViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveSerieViewModel vm)
        {
            ViewBag.productoras = await producerService.GetAll();
            ViewBag.generos = await genderService.GetAll();

            if (!ModelState.IsValid)
            {
                return View("SaveSerie", vm);
            }
            await serieService.Update(vm);
            return RedirectToRoute(new { controller = "Serie", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await serieService.GetByIdViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await serieService.Delete(id);
            return RedirectToRoute(new { controller = "Serie", action = "Index" });
        }
    }
}
