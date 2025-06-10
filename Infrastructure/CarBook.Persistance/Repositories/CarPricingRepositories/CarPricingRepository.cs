using CarBook.Application.Enum;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.ViewModels;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistance.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<CarPricing>> GetCarPricingWithCars()
        {
            var values = await _context.CarPricings.Include(x => x.Car).ThenInclude(x => x.Brand).Include(x => x.Pricing).Where(z => z.PricingId == 2).ToListAsync();
            return values;
        }

        public async Task<List<CarPricingViewModel>> GetCarPricingWithTimePeriod()
        {
            var values = from cp in _context.CarPricings
                         join c in _context.Cars on cp.CarId equals c.CarId
                         join b in _context.Brands on c.BrandId equals b.BrandId
                         group cp by new { b.Name, c.Model, c.CoverImageUrl } into grouped
                         select new CarPricingViewModel
                         {
                             Model = grouped.Key.Name + " " + grouped.Key.Model,
                             CoverImageUrl = grouped.Key.CoverImageUrl,
                             DailyPrice = grouped.Where(x => x.PricingId == (int)PricingType.Daily).Sum(x => x.Amount),
                             WeeklyPrice = grouped.Where(x => x.PricingId == (int)PricingType.Weekly).Sum(x => x.Amount),
                             MonthlyPrice = grouped.Where(x => x.PricingId == (int)PricingType.Monthly).Sum(x => x.Amount)
                         };

            return values.ToList();
        }



        /**
         Select * From 
        (
        Select b.Name+' '+c.Model as Araba,PricingId,Amount
        From CarPricings cp
        Inner Join Cars c 
        on c.CarId = cp.CarId
        Inner Join Brands b
        on b.BrandId = c.BrandId
        )
        As SourceTable
        Pivot (
        Sum(Amount) For PricingId In ([2],[3],[4])
        ) as PivotTable 
        **/
    }
}
