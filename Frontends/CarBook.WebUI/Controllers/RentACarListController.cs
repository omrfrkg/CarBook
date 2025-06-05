using System.Text;
using CarBook.Dto.RentACarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RentACarListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            var book_pick_date = TempData["bookpickdate"];
            var book_off_date = TempData["bookoffdate"];
            var time_pick = TempData["timepick"];
            var time_off = TempData["timeoff"];
            var locationId = TempData["locationId"];

            ViewBag.book_pick_date = book_pick_date;
            ViewBag.book_off_date = book_off_date;
            ViewBag.time_pick = time_pick;
            ViewBag.time_off = time_off;
            ViewBag.locationId = locationId;

            id = int.Parse(locationId.ToString());

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7031/api/RentACars?locationId={id}&available=true");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<FilterRentACarDto>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
