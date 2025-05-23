namespace CarBook.Application.Features.Mediator.Results.BlogResults
{
    public class GetAuthorByBlogIdQueryResult
    {
        public int BlogId { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string ImageUrl { get; set; }
        public string AuthorDescription { get; set; }
    }
}
