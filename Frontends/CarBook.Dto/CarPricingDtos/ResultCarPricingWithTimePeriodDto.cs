namespace CarBook.Dto.CarPricingDtos
{
    public class ResultCarPricingWithTimePeriodDto
    {
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public decimal DailyPrice { get; set; }
        public decimal WeeklyPrice { get; set; }
        public decimal MonthlyPrice { get; set; }
    }
}
