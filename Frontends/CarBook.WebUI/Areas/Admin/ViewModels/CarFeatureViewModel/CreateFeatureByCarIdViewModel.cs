using CarBook.Dto.CarFeatureDtos;
using CarBook.Dto.FeatureDtos;

namespace CarBook.WebUI.Areas.Admin.ViewModels.CarFeatureViewModel
{
    public class CreateFeatureByCarIdViewModel
    {
        public List<ResultFeatureDto> Features { get; set; }
        public CreateCarFeatureByCarDto CarFeatures { get; set; }
    }
}
