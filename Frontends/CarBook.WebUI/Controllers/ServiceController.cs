using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.t1 = "Hizmetler";
            ViewBag.t2 = "Hizmetlerimiz";
            return View();
        }
    }
}
