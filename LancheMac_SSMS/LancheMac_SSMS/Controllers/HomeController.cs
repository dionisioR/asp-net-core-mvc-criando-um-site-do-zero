using LancheMac_SSMS.Models;
using LancheMac_SSMS.Repositories.Interfaces;
using LancheMac_SSMS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LancheMac_SSMS.Controllers {
    public class HomeController : Controller {

        private readonly ILancheRepository _lancheRepository;

        public HomeController(ILancheRepository lancheRepository) {
            _lancheRepository = lancheRepository;
        }

        public IActionResult Index() {

            TempData["Nome"] = "RD3W";

            var homeViewModel = new HomeViewModel {
                LanchesPreferidos = _lancheRepository.LanchesPreferidos
            };

            return View(homeViewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
