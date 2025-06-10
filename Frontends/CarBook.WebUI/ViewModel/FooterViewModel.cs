using CarBook.Dto.FooterAddressDtos;
using CarBook.Dto.SocialMediaDtos;

namespace CarBook.WebUI.ViewModel
{
    public class FooterViewModel
    {
        public List<ResultFooterAddressDto> FooterAddresses { get; set; }
        public List<ResultSocialMediaDto> SocialMedias { get; set; }
    }
}
