using CarBook.Application.Interfaces.StatisticsInterfaces;
using CarBook.Persistance.Context;

namespace CarBook.Persistance.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;

        public StatisticsRepository(CarBookContext context)
        {
            _context = context;
        }

        public string GetBlogTitleByMaxBlogComment()
        {
            var values = _context.Comments.GroupBy(x => x.BlogId).Select(y => new
                        {
                            BlogId = y.Key,
                            CommentCount = y.Count()
                        }).OrderByDescending(z => z.CommentCount).Take(1).FirstOrDefault();
            string blogName = _context.Blogs.Where(x => x.BlogId == values.BlogId).Select(x => x.Title).FirstOrDefault();
            return blogName;
        }

        public int GetAuthorCount()
        {
            var value = _context.Authors.Count();
            return value;
        }

        public decimal GetAvgRentPriceForDaily()
        {
            int id = _context.Pricings.Where(y => y.Name == "Günlük").Select(z => z.PricingId).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.CarPricingId == id).Average(x => x.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForMonthly()
        {
            int id = _context.Pricings.Where(y => y.Name == "Aylık").Select(z => z.PricingId).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.CarPricingId == id).Average(x => x.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForWeekly()
        {
            int id = _context.Pricings.Where(y => y.Name == "Haftalık").Select(z => z.PricingId).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.CarPricingId == id).Average(x => x.Amount);
            return value;
        }

        public int GetBlogCount()
        {
            var value = _context.Blogs.Count();
            return value;
        }

        public int GetBrandCount()
        {
            var value = _context.Brands.Count();
            return value;
        }

        public string GetBrandNameByMaxCar()
        {
            var value = (from c in _context.Cars
                          join b in _context.Brands
                          on c.BrandId equals b.BrandId
                          group c by b.Name into g
                          select new
                          {
                              Name = g.Key,
                              AracSayisi = g.Count()
                          })
             .OrderByDescending(g => g.AracSayisi)
             .Take(1)
             .FirstOrDefault();
            return value.Name;
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
            var value = _context.CarPricings
                        .Join(_context.Cars,
                              cp => cp.CarId,
                              c => c.CarId,
                              (cp, c) => new { CarPricing = cp, Car = c })
                        .Join(_context.Brands,
                              x => x.Car.BrandId,
                              b => b.BrandId,
                              (x, b) => new { x.CarPricing, x.Car, Brand = b })
                        .Where(x => x.CarPricing.Amount == _context.CarPricings
                            .Join(_context.Pricings,
                                  cp2 => cp2.PricingId,
                                  p => p.PricingId,
                                  (cp2, p) => new { CarPricing = cp2, Pricing = p })
                            .Where(y => y.Pricing.Name == "Günlük")
                            .Select(y => y.CarPricing.Amount)
                            .Max())
                        .Select(x => new
                        {
                            ModelAdi = x.Brand.Name + " " + x.Car.Model
                        }).FirstOrDefault();
            return value.ModelAdi;

            /*
             * Select (Brands.Name + ' ' + Cars.Model) AS ModelAdi
                From CarPricings 
                Inner Join Cars on Cars.CarId = CarPricings.CarId 
                Inner Join Brands on Brands.BrandId = Cars.BrandId 
                Where Amount=(
                                Select Max(Amount) 
                                From CarPricings 
                                Inner Join Pricings on Pricings.PricingId = CarPricings.PricingId 
                                Where Pricings.Name = 'Günlük')
             */
        }

        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            var value = _context.CarPricings
                        .Join(_context.Cars,
                              cp => cp.CarId,
                              c => c.CarId,
                              (cp, c) => new { CarPricing = cp, Car = c })
                        .Join(_context.Brands,
                              x => x.Car.BrandId,
                              b => b.BrandId,
                              (x, b) => new { x.CarPricing, x.Car, Brand = b })
                        .Where(x => x.CarPricing.Amount == _context.CarPricings
                            .Join(_context.Pricings,
                                  cp2 => cp2.PricingId,
                                  p => p.PricingId,
                                  (cp2, p) => new { CarPricing = cp2, Pricing = p })
                            .Where(y => y.Pricing.Name == "Günlük")
                            .Select(y => y.CarPricing.Amount)
                            .Min())
                        .Select(x => new
                        {
                            ModelAdi = x.Brand.Name + " " + x.Car.Model
                        }).FirstOrDefault();
            return value.ModelAdi;

        }

        public int GetCarCount()
        {
            var value = _context.Cars.Count();
            return value;
        }

        public int GetCarCountByFuelElectric()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Elektrik").Count();
            return value;
        }

        public int GetCarCountByFuelGasolineOrDiesel()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").Count();
            return value;
        }

        public int GetCarCountByKmSmallerThen1000()
        {
            var value = _context.Cars.Where(x => x.Km < 10000).Count();
            return value;
        }

        public int GetCarCountByTransmissionIsAuto()
        {
            var value = _context.Cars.Where(x => x.Transmission == "Otomatik").Count();
            return value;
        }

        public int GetLocationCount()
        {
            var value = _context.Locations.Count();
            return value;
        }
    }
}
