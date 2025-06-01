using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistics")]
    public class AdminStatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            Random random = new Random();
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7031/api/Statistics/GetCarCount");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                int carCountRandom = random.Next(1, 101);
                var value = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.carCount = value.CarCount;
                ViewBag.carCountRandom = carCountRandom;

            }

            var responseMessage2 = await client.GetAsync("https://localhost:7031/api/Statistics/GetLocationCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                int locationCountRandom = random.Next(1, 101);
                var value2 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData2);
                ViewBag.locationCount = value2.LocationCount;
                ViewBag.locationCountRandom = locationCountRandom;
            }

            return View();
        }
    }
}
