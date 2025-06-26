using CarBook.Application.Interfaces.StatisticsInterfaces;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;

        public StatisticsRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<string> GetBlogTitleByMaxBlogComment()
        {
            return await _context.Comments
        .GroupBy(c => c.BlogID)
        .OrderByDescending(g => g.Count())
        .Select(g => g.Key)
        .Join(_context.Blogs,
            blogId => blogId,
            blog => blog.BlogID,
            (blogId, blog) => blog.Title)
        .FirstOrDefaultAsync();
        }

        public async Task<string> GetBrandNameByMaxCar()
        {
            var brandName = await _context.Cars
                .GroupBy(c => c.BrandID)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .Join(_context.Brands,
                      brandId => brandId,
                      brand => brand.BrandID,
                      (brandId, brand) => brand.Name)
                .FirstOrDefaultAsync();

            return brandName ?? "Marka bulunamadı";
        }

        public int GetAuthorCount()
        {
            var value = _context.Authors.Count();
            return value;
        }

        public decimal GetAvgRentPriceForDaily()
        {
            int id = _context.Pricings.Where(y => y.Name == "Günlük").Select(z => z.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(x => x.PricingID == id).Average(w => w.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForMonthly()
        {
            int id = _context.Pricings.Where(y => y.Name == "Aylık").Select(z => z.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(x => x.PricingID == id).Average(w => w.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForWeekly()
        {
            int id = _context.Pricings.Where(y => y.Name == "Haftalık").Select(z => z.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(x => x.PricingID == id).Average(w => w.Amount);
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

        public async Task<string> GetCarBrandAndModelByRentPriceDailyMax()
        {
            return await _context.Pricings
        .Where(p => p.Name == "Günlük")
        .Join(_context.CarPricings,
            pricing => pricing.PricingID,
            carPricing => carPricing.PricingID,
            (pricing, carPricing) => carPricing)
        .OrderByDescending(cp => cp.Amount)
        .Take(1)
        .Join(_context.Cars,
            carPricing => carPricing.CarID,
            car => car.CarID,
            (carPricing, car) => car.BrandID)
        .Join(_context.Brands,
            brandId => brandId,
            brand => brand.BrandID,
            (brandId, brand) => brand.Name)
        .FirstOrDefaultAsync();
        }

        public async Task<string> GetCarBrandAndModelByRentPriceDailyMin()
        {
            return await _context.Pricings
        .Where(p => p.Name == "Günlük")
        .Join(_context.CarPricings,
            pricing => pricing.PricingID,
            carPricing => carPricing.PricingID,
            (pricing, carPricing) => carPricing)
        .OrderBy(cp => cp.Amount)
        .Take(1)
        .Join(_context.Cars,
            carPricing => carPricing.CarID,
            car => car.CarID,
            (carPricing, car) => car.BrandID)
        .Join(_context.Brands,
            brandId => brandId,
            brand => brand.BrandID,
            (brandId, brand) => brand.Name)
        .FirstOrDefaultAsync();
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
            return  _context.Cars
        .Count(c => c.Fuel == "Benzin" || c.Fuel == "Dizel");
        }

        public int GetCarCountByKmSmallerThen1000()
        {
            var value = _context.Cars.Where(x => x.Km <= 1000).Count();
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
