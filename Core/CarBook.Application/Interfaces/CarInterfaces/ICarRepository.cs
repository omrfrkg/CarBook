using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.CarInterfaces
{
    public interface ICarRepository
    {
        Task<List<Car>> GetCarsListWithBrands();
        Task<List<Car>> GetLast5CarsWithBrands();
        Task<Car> GetCarWithBrandById(int id);
        
    }
}
