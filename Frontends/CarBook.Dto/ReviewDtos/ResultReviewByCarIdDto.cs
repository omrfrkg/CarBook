namespace CarBook.Dto.ReviewDtos
{
    public class ResultReviewByCarIdDto
    {
        public int ReviewId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerImage { get; set; }
        public string Comment { get; set; }
        public int ReytingValue { get; set; }
        public DateTime ReviewDate { get; set; }
        public int CarId { get; set; }
    }
}
