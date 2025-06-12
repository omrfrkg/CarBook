using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.ViewComponents.DashboardComponents
{
    public class _AdminDashboardStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _AdminDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
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

            var responseMessage3 = await client.GetAsync("https://localhost:7031/api/Statistics/GetBrandCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                int brandCountRandom = random.Next(1, 101);
                var value3 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData3);
                ViewBag.brandCount = value3.BrandCount;
                ViewBag.brandCountRandom = brandCountRandom;
            }

            var responseMessage4 = await client.GetAsync("https://localhost:7031/api/Statistics/GetAvgRentPriceForDaily");
            if (responseMessage4.IsSuccessStatusCode)
            {
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                int avgRentPriceForDailyRandom = random.Next(1, 101);
                var value4 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData4);
                ViewBag.avgRentPriceForDaily = value4.AvgPriceForDaily.ToString("N2");
                ViewBag.avgRentPriceForDailyRandom = avgRentPriceForDailyRandom;
            }
            return View();
        }
    }
}
