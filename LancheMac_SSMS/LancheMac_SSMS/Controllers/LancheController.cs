using LancheMac_SSMS.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LancheMac_SSMS.Controllers {
    public class LancheController : Controller {

        private readonly ILancheRepository _lacheRepository;

        public LancheController(ILancheRepository lacheRepository) {
            _lacheRepository = lacheRepository;
        }

        public IActionResult List() {
            var lanches = _lacheRepository.Lanches;
            return View(lanches);
        }
    }
}
