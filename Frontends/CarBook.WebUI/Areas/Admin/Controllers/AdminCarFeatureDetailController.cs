using System.Text;
using CarBook.Dto.CarFeatureDtos;
using CarBook.Dto.FeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCarFeatureDetail")]
    public class AdminCarFeatureDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminCarFeatureDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7031/api/CarFeatures?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdDto> resultCarFeatureByCarIdDto)
        {
            foreach(var item in resultCarFeatureByCarIdDto)
            {
                if (item.Available)
                {
                    var client = _httpClientFactory.CreateClient();
                    var responseMessage = await client.GetAsync("https://localhost:7031/api/CarFeatures/CarFeatureChangeAvailableToTrue?id=" + item.CarFeatureId);
                }
                else
                {
                    var client = _httpClientFactory.CreateClient();
                    var responseMessage = await client.GetAsync("https://localhost:7031/api/CarFeatures/CarFeatureChangeAvailableToFalse?id=" + item.CarFeatureId);
                }
            }
            return RedirectToAction("Index", "AdminCar");
        }

        [HttpGet]
        [Route("CreateFeatureByCarId/{id}")]
        public async Task<IActionResult> CreateFeatureByCarId(int id)
        {
            ViewBag.carId = id;

            var client = _httpClientFactory.CreateClient();            
            var responseMessage = await client.GetAsync("https://localhost:7031/api/Features");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureWithStatusDto>>(jsonData);
                CreateCarFeatureByCarDto model = new CreateCarFeatureByCarDto();
                model.Features = values;
                model.CarId = id;
                return View(model);
            }

            return View();

            
        }

        [HttpPost]
        [Route("CreateFeatureByCarId/{id}")]
        public async Task<IActionResult> CreateFeatureByCarId(CreateCarFeatureByCarDto createCarFeatureByCarDto)
        {
            CreateCarFeatureDetailDto model = new CreateCarFeatureDetailDto();
            model.CarId = createCarFeatureByCarDto.CarId;

            var client = _httpClientFactory.CreateClient();
            foreach(var item in createCarFeatureByCarDto.Features)
            {
                if (item.Status)
                {
                    model.FeatureId = item.FeatureId;
                    var jsonData = JsonConvert.SerializeObject(model);
                    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    await client.PostAsync("https://localhost:7031/api/CarFeatures", stringContent);
                }
            }

            return RedirectToAction("Index", "AdminCar", new {area="Admin"});
        }
    }
}
