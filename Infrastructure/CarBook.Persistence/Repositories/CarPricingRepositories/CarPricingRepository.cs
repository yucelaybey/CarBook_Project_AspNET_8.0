using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Domain.Entities;
using CarBook.Dto.CarPricingDtos;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<CarPricing> GetCarPricingWithCars()
        {
            var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(z => z.Pricing).Where(z => z.PricingID == 2).ToList();
            return values;
        }

        public async Task<List<CarPricingInfoDto>> GetCarPricingWithTimePeriod()
        {
            return await _context.Cars
                .AsNoTracking()
                .Include(c => c.Brand)
                .Include(c => c.CarPricings)
                    .ThenInclude(cp => cp.Pricing)
                .Select(c => new CarPricingInfoDto
                {
                    Brand = c.Brand.Name,
                    Model = c.Model,
                    CoverImageUrl = c.CoverImageUrl,
                    DailyAmount = c.CarPricings
                        .Where(cp => cp.Pricing.Name == "Günlük")
                        .Select(cp => cp.Amount)
                        .FirstOrDefault(),
                    WeeklyAmount = c.CarPricings
                        .Where(cp => cp.Pricing.Name == "Haftalık")
                        .Select(cp => cp.Amount)
                        .FirstOrDefault(),
                    MonthlyAmount = c.CarPricings
                        .Where(cp => cp.Pricing.Name == "Aylık")
                        .Select(cp => cp.Amount)
                        .FirstOrDefault()
                })
                .Where(x => x.DailyAmount > 0 || x.WeeklyAmount > 0 || x.MonthlyAmount > 0)
                .ToListAsync();
        }
    }
}
