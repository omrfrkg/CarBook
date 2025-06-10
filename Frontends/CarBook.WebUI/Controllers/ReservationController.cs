using System.Text;
using CarBook.Dto.LocationDtos;
using CarBook.Dto.ReservationDtos;
using CarBook.Dto.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.t1 = "Araç Kiralama";
            ViewBag.t2 = "Araç Rezarvasyon Formu";
            ViewBag.carId = id;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7031/api/Locations");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
            List<SelectListItem> value2 = (from x in values
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.LocationId.ToString()
                                           }).ToList();
            ViewBag.location = value2;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateReservationDto createReservationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createReservationDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7031/api/Reservations", content);

            // ViewBag.v'yi tekrar doldur
            var locationResponse = await client.GetAsync("https://localhost:7031/api/Locations");
            var locationJsonData = await locationResponse.Content.ReadAsStringAsync();
            var locationValues = JsonConvert.DeserializeObject<List<ResultLocationDto>>(locationJsonData);
            List<SelectListItem> value2 = (from x in locationValues
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.LocationId.ToString()
                                           }).ToList();
            ViewBag.location = value2;

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = true;
                return View();
            }
            return View();
        }
    }
}
