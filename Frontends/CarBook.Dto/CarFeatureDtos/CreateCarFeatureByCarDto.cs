using CarBook.Dto.FeatureDtos;

namespace CarBook.Dto.CarFeatureDtos
{
    public class CreateCarFeatureByCarDto
    {
        public List<ResultFeatureWithStatusDto> Features { get; set; }
        public int CarId { get; set; }

        //public int FeatureID { get; set; }
        //public bool Available { get; set; }
    }
}
