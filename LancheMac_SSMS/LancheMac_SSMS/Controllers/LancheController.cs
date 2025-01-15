using LancheMac_SSMS.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LancheMac_SSMS.Controllers {
    public class LancheController : Controller {

        private readonly ILancheRepository _lacheRepository;

        public LancheController(ILancheRepository lacheRepository) {
            _lacheRepository = lacheRepository;
        }

        public IActionResult List() {
            ViewData["Titulo"] = "Todos os lanches";
            ViewData["Data"] = DateTime.Now;

            var lanches = _lacheRepository.Lanches;

            ViewBag.Total = "Total de lanches";
            ViewBag.TotalLanches = lanches.Count();

            return View(lanches);
        }
    }
}
