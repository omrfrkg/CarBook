namespace CarBook.Dto.BlogDtos
{
    public class GetAuthorByBlogIdDto
    {
        public int BlogId { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string ImageUrl { get; set; }
        public string AuthorDescription { get; set; }
    }
}
