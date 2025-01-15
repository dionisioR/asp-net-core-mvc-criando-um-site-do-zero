using LancheMac_SSMS.Repositories.Interfaces;
using LancheMac_SSMS.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LancheMac_SSMS.Controllers {
    public class LancheController : Controller {

        private readonly ILancheRepository _lancheRepository;

        public LancheController(ILancheRepository lacheRepository) {
            _lancheRepository = lacheRepository;
        }

        public IActionResult List() {
            ViewData["Titulo"] = "Todos os lanches";
            ViewData["Data"] = DateTime.Now;

            var lanches = _lancheRepository.Lanches;

            ViewBag.Total = "Total de lanches";
            ViewBag.TotalLanches = lanches.Count();

            //EXEMPLO COM  ViewModel
            var lanchesListViewModel = new LancheListViewModel();
            lanchesListViewModel.Lanches = _lancheRepository.Lanches;
            lanchesListViewModel.CategoriaAtual = "Categoria Atual";

            // return View(lanches);
            return View(lanchesListViewModel);
        }
    }
}
