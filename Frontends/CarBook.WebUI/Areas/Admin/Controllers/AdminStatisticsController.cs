using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
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
                ViewBag.avgRentPriceForDaily = value6.AvgPriceForDaily.ToString("N2");
                ViewBag.avgRentPriceForDailyRandom = avgRentPriceForDailyRandom;
            }

            var responseMessage7 = await client.GetAsync("https://localhost:7031/api/Statistics/GetAvgRentPriceForWeekly");
            if (responseMessage7.IsSuccessStatusCode)
            {
                var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
                int avgRentPriceForWeeklyRandom = random.Next(1, 101);
                var value7 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData7);
                ViewBag.avgRentPriceForWeekly = value7.AvgPriceForWeekly.ToString("N2");
                ViewBag.avgRentPriceForWeeklyRandom = avgRentPriceForWeeklyRandom;
            }

            var responseMessage8 = await client.GetAsync("https://localhost:7031/api/Statistics/GetAvgRentPriceForMonthly");
            if (responseMessage8.IsSuccessStatusCode)
            {
                var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
                int avgRentPriceForMonthlyRandom = random.Next(1, 101);
                var value8 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData8);
                ViewBag.avgRentPriceForMonthly = value8.AvgPriceForMonthly.ToString("N2");
                ViewBag.avgRentPriceForMonthlyRandom = avgRentPriceForMonthlyRandom;
            }

            var responseMessage9 = await client.GetAsync("https://localhost:7031/api/Statistics/GetCarCountByTransmissionIsAuto");
            if (responseMessage9.IsSuccessStatusCode)
            {
                var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
                int carCountByTransmissionIsAutoRandom = random.Next(1, 101);
                var value9 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData9);
                ViewBag.carCountByTransmissionIsAuto = value9.CarCountByTransmissionIsAuto;
                ViewBag.carCountByTransmissionIsAutoRandom = carCountByTransmissionIsAutoRandom;
            }

            var responseMessage10 = await client.GetAsync("https://localhost:7031/api/Statistics/GetBrandNameByMaxCar");
            if (responseMessage10.IsSuccessStatusCode)
            {
                var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
                int brandNameByMaxCarRandom = random.Next(1, 101);
                var value10 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData10);
                ViewBag.brandNameByMaxCar = value10.BrandNameByMaxCar;
                ViewBag.brandNameByMaxCarRandom = brandNameByMaxCarRandom;
            }

            var responseMessage11 = await client.GetAsync("https://localhost:7031/api/Statistics/GetBlogTitleByMaxBlogComment");
            if (responseMessage11.IsSuccessStatusCode)
            {
                var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
                int blogTitleByMaxBlogCommentRandom = random.Next(1, 101);
                var value11 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData11);
                ViewBag.blogTitleByMaxBlogComment = value11.BlogTitleByMaxBlogComment;
                ViewBag.blogTitleByMaxBlogCommentRandom = blogTitleByMaxBlogCommentRandom;
            }

            var responseMessage12 = await client.GetAsync("https://localhost:7031/api/Statistics/GetCarCountByKmSmallerThen1000");
            if (responseMessage12.IsSuccessStatusCode)
            {
                var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
                int carCountByKmSmallerThen1000Random = random.Next(1, 101);
                var value12 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData12);
                ViewBag.carCountByKmSmallerThen1000 = value12.CarCountByKmSmallerThen1000;
                ViewBag.carCountByKmSmallerThen1000Random = carCountByKmSmallerThen1000Random;
            }

            var responseMessage13 = await client.GetAsync("https://localhost:7031/api/Statistics/GetCarCountByFuelGasolineOrDiesel");
            if (responseMessage13.IsSuccessStatusCode)
            {
                var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
                int carCountByFuelGasolineOrDieselRandom = random.Next(1, 101);
                var value13 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData13);
                ViewBag.carCountByFuelGasolineOrDiesel = value13.CarCountByFuelGasolineOrDiesel;
                ViewBag.carCountByFuelGasolineOrDieselRandom = carCountByFuelGasolineOrDieselRandom;
            }

            var responseMessage14 = await client.GetAsync("https://localhost:7031/api/Statistics/GetCarCountByFuelElectric");
            if (responseMessage14.IsSuccessStatusCode)
            {
                var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
                int carCountByFuelElectricRandom = random.Next(1, 101);
                var value14 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData14);
                ViewBag.carCountByFuelElectric = value14.CarCountByFuelElectric;
                ViewBag.carCountByFuelElectricRandom = carCountByFuelElectricRandom;
            }

            var responseMessage15 = await client.GetAsync("https://localhost:7031/api/Statistics/GetCarBrandAndModelByRentPriceDailyMax");
            if (responseMessage15.IsSuccessStatusCode)
            {
                var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();
                int getCarBrandAndModelByRentPriceDailyMaxRandom = random.Next(1, 101);
                var value15 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData15);
                ViewBag.getCarBrandAndModelByRentPriceDailyMax = value15.GetCarBrandAndModelByRentPriceDailyMax;
                ViewBag.getCarBrandAndModelByRentPriceDailyMaxRandom = getCarBrandAndModelByRentPriceDailyMaxRandom;
            }

            var responseMessage16 = await client.GetAsync("https://localhost:7031/api/Statistics/GetCarBrandAndModelByRentPriceDailyMin");
            if (responseMessage16.IsSuccessStatusCode)
            {
                var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
                int carBrandAndModelByRentPriceDailyMinRandom = random.Next(1, 101);
                var value16 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData16);
                ViewBag.carBrandAndModelByRentPriceDailyMin = value16.CarBrandAndModelByRentPriceDailyMin;
                ViewBag.carBrandAndModelByRentPriceDailyMinRandom = carBrandAndModelByRentPriceDailyMinRandom;
            }



            return View();
        }
    }
}
