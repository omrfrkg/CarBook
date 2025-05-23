using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistance.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext _context;

        public BlogRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<Blog>> GetAllBlogsWithAuthors()
        {
            var values = await _context.Blogs.Include(x => x.Author).ToListAsync();
            return values;
        }

        public async Task<Blog> GetAuthorByBlogId(int id)
        {
            var value = await _context.Blogs.Include(x => x.Author).Where(x => x.BlogId == id).FirstOrDefaultAsync();
            return value;
        }

        public async Task<List<Blog>> GetLast3BlogsWithAuthors()
        {
            var values = await _context.Blogs.Include(x => x.Author).OrderByDescending(x => x.BlogId).Take(3).ToListAsync();
            return values;
        }
    }
}
