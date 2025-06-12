using CarBook.Application.Interfaces.CarFeatureInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistance.Repositories.CarFeatureRepositories
{
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly CarBookContext _context;

        public CarFeatureRepository(CarBookContext context)
        {
            _context = context;
        }

        public void ChangeCarFeatureAvailableToFalse(int id)
        {
            var value = _context.CarFeatures.Where(x => x.CarFeatureId == id).FirstOrDefault();
            value.Available = false;
            _context.SaveChanges();
        }

        public void ChangeCarFeatureAvailableToTrue(int id)
        {
            var value = _context.CarFeatures.Where(x => x.CarFeatureId == id).FirstOrDefault();
            value.Available = true;
            _context.SaveChanges();
        }

        public async Task CreateCarFeatureByCar (CarFeature carFeature)
        {
            var value = await _context.CarFeatures.Where(x => x.CarId == carFeature.CarId && x.FeatureID == carFeature.FeatureID).FirstOrDefaultAsync();
            
            if(value is null)
            {
                await _context.CarFeatures.AddRangeAsync(carFeature);
                await _context.SaveChangesAsync();
            }
        }

        public List<CarFeature> GetCarFeaturesByCarId(int carId)
        {
            var values = _context.CarFeatures.Include(y => y.Feature).Where(x => x.CarId == carId).ToList();
            return values;
        }
    }
}
