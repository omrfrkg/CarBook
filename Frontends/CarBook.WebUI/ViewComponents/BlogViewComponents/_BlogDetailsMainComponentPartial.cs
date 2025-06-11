using CarBook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsMainComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailsMainComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {


            var client = _httpClientFactory.CreateClient();

            var responseMessage2 = await client.GetAsync($"https://localhost:7031/api/Comments/GetCountCommentByBlogId/" + id);
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            //var commentCount = JsonConvert.DeserializeObject<int>(jsonData2);
            ViewBag.commentCount = jsonData2;

            var responseMessage = await client.GetAsync($"https://localhost:7031/api/Blogs/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetBlogByIdDto>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
