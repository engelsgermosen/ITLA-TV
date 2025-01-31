using ITLA_TV.Core.Application.Interfaces.Services;
using ITLA_TV.Core.Application.ViewModels.Producers;
using Microsoft.AspNetCore.Mvc;

namespace ITLA_TV.Controllers
{
    public class ProducerController : Controller
    {
        private readonly IProducerService producerService;

        public ProducerController(IProducerService producerService)
        {
            this.producerService = producerService;   
        }

        public async Task<IActionResult> Index()
        {
            return View(await producerService.GetAll());
        }

        public IActionResult Create()
        {
            return View("SaveProducer", new SaveProducerViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveProducerViewModel vm)
        {

            if (!ModelState.IsValid)
            {
                return View("SaveProducer", vm);
            }
            await producerService.Add(vm);
            return RedirectToRoute(new { controller = "Producer", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {

            return View("SaveProducer", await producerService.GetByIdViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveProducerViewModel vm)
        {

            if (!ModelState.IsValid)
            {
                return View("SaveProducer", vm);
            }
            await producerService.Update(vm);
            return RedirectToRoute(new { controller = "Producer", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await producerService.GetByIdViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await producerService.Delete(id);
            return RedirectToRoute(new { controller = "Producer", action = "Index" });
        }
    }
}
