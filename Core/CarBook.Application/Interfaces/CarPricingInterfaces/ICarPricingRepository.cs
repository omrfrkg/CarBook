using CarBook.Application.ViewModels;
using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.CarPricingInterfaces
{
    public interface ICarPricingRepository
    {
        Task<List<CarPricing>> GetCarPricingWithCars();
        Task<List<CarPricingViewModel>> GetCarPricingWithTimePeriod();
    }
}
