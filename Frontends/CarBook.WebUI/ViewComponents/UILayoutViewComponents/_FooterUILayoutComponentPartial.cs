using CarBook.Dto.FooterAddressDtos;
using CarBook.Dto.SocialMediaDtos;
using CarBook.WebUI.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _FooterUILayoutComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _FooterUILayoutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var viewModel = new FooterViewModel
            {
                FooterAddresses = new List<ResultFooterAddressDto>(),
                SocialMedias = new List<ResultSocialMediaDto>()
            };


            var footerTask = client.GetAsync("https://localhost:7031/api/FooterAddresses");
            var socialMediaTask = client.GetAsync("https://localhost:7031/api/SocialMedias");

            await Task.WhenAll(footerTask, socialMediaTask);


            var footerAddressResponse = await footerTask;
            if (footerAddressResponse.IsSuccessStatusCode)
            {
                var jsonData = await footerAddressResponse.Content.ReadAsStringAsync();
                viewModel.FooterAddresses = JsonConvert.DeserializeObject<List<ResultFooterAddressDto>>(jsonData);
                
            }

            var socialMediaResponse = await socialMediaTask;
            if (socialMediaResponse.IsSuccessStatusCode)
            {
                var jsonData = await socialMediaResponse.Content.ReadAsStringAsync();
                viewModel.SocialMedias = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData);
            }

            return View(viewModel);
        }
    }
}
