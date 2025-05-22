using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.BlogInterfaces
{
    public interface IBlogRepository
    {
        public Task<List<Blog>> GetLast3BlogsWithAuthors();
        public Task<List<Blog>> GetAllBlogsWithAuthors();
    }
}
