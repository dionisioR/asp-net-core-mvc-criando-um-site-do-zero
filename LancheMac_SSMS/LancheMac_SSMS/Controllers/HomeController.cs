using LancheMac_SSMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LancheMac_SSMS.Controllers {
    public class HomeController : Controller {
      
        public IActionResult Index() {

            TempData["Nome"] = "RD3W";
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
