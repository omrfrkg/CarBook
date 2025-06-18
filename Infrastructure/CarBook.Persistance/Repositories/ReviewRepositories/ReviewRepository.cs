using CarBook.Application.Interfaces.ReviewInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistance.Repositories.ReviewRepositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly CarBookContext _context;
        public ReviewRepository(CarBookContext context)
        {
            _context = context;
        }

        public Task<List<Review>> GetReviewsByCarId(int carId)
        {
            var values = _context.Reviews.Where(x => x.CarId == carId).ToListAsync();
            return values;
        }
    }
}
