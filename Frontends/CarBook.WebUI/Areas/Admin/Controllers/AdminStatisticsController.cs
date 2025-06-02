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

            var responseMessage3 = await client.GetAsync("https://localhost:7031/api/Statistics/GetAuthorCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                int authorCountRandom = random.Next(1, 101);
                var value3 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData3);
                ViewBag.authorCount = value3.AuthorCount;
                ViewBag.authorCountRandom = authorCountRandom;
            }

            var responseMessage4 = await client.GetAsync("https://localhost:7031/api/Statistics/GetBlogCount");
            if (responseMessage4.IsSuccessStatusCode)
            {
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                int blogCountRandom = random.Next(1, 101);
                var value4 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData4);
                ViewBag.blogCount = value4.BlogCount;
                ViewBag.blogCountRandom = blogCountRandom;
            }

            var responseMessage5 = await client.GetAsync("https://localhost:7031/api/Statistics/GetBrandCount");
            if (responseMessage5.IsSuccessStatusCode)
            {
                var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
                int brandCountRandom = random.Next(1, 101);
                var value5 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData5);
                ViewBag.brandCount = value5.BrandCount;
                ViewBag.brandCountRandom = brandCountRandom;
            }

            var responseMessage6 = await client.GetAsync("https://localhost:7031/api/Statistics/GetAvgRentPriceForDaily");
            if (responseMessage6.IsSuccessStatusCode)
            {
                var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
                int avgRentPriceForDailyRandom = random.Next(1, 101);
                var value6 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData6);
                ViewBag.avgRentPriceForDaily = value6.AvgRentPriceForDaily;
                ViewBag.avgRentPriceForDailyRandom = avgRentPriceForDailyRandom;
            }

            return View();
        }
    }
}
