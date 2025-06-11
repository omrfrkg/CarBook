namespace CarBook.Dto.CarFeatureDtos
{
    public class CreateCarFeatureByCarDto
    {
        public int CarId { get; set; }
        public int FeatureID { get; set; }
        public bool Available { get; set; }
    }
}
