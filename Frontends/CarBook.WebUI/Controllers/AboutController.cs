using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class AboutController : Controller
    {

        public IActionResult Index()
        {
            ViewBag.t1 = "Hakkımızda";
            ViewBag.t2 = "Vizyonumuz & Misyonumuz";
            return View();
        }
    }
}
