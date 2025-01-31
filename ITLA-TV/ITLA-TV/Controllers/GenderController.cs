using ITLA_TV.Core.Application.Interfaces.Services;
using ITLA_TV.Core.Application.ViewModels.Genres;
using Microsoft.AspNetCore.Mvc;

namespace ITLA_TV.Controllers
{
    public class GenderController : Controller
    {
        private readonly IGenderService genderService;

        public GenderController(IGenderService service)
        {
            genderService = service;
        }
        public async Task<IActionResult> Index()
        {
            return View(await genderService.GetAll());
        }

        public IActionResult Create()
        {
            return View("SaveGender", new SaveGenresViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveGenresViewModel vm)
        {

            if (!ModelState.IsValid)
            {
                return View("SaveGender", vm);
            }
            await genderService.Add(vm);
            return RedirectToRoute(new { controller = "Gender", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {

            return View("SaveGender", await genderService.GetByIdViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveGenresViewModel vm)
        {

            if (!ModelState.IsValid)
            {
                return View("SaveGender", vm);
            }
            await genderService.Update(vm);
            return RedirectToRoute(new { controller = "Gender", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await genderService.GetByIdViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await genderService.Delete(id);
            return RedirectToRoute(new { controller = "Gender", action = "Index" });
        }
    }
}
