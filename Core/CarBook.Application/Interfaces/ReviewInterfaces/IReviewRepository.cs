using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.ReviewInterfaces
{
    public interface IReviewRepository
    {
        Task<List<Review>> GetReviewsByCarId(int carId);
    }
}
