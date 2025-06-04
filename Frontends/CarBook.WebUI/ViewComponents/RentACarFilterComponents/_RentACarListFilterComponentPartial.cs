using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.RentACarFilterComponents
{
    public class _RentACarListFilterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke(string iadeSaati)
        {
            TempData["iadeSaati"] = iadeSaati;
            return View();
        }
    }
}
