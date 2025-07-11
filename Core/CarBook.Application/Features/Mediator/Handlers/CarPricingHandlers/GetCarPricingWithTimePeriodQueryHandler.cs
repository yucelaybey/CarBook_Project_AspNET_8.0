﻿using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingWithTimePeriodQueryHandler : IRequestHandler<GetCarPricingWithTimePeriodQuery, List<GetCarPricingWithTimePeriodQueryResult>>
    {
        private readonly ICarPricingRepository _carPricingRepository;

        public GetCarPricingWithTimePeriodQueryHandler(ICarPricingRepository carPricingRepository)
        {
            _carPricingRepository = carPricingRepository;
        }

        public async Task<List<GetCarPricingWithTimePeriodQueryResult>> Handle(
    GetCarPricingWithTimePeriodQuery request,
    CancellationToken cancellationToken)
        {
            var values = await _carPricingRepository.GetCarPricingWithTimePeriod();
            return values.Select(x => new GetCarPricingWithTimePeriodQueryResult
            {
                Brand = x.Brand,
                Model = x.Model,
                CoverImageUrl =x.CoverImageUrl,
                DailyAmount = x.DailyAmount,
                MonthlyAmount = x.MonthlyAmount,
                WeeklyAmount = x.WeeklyAmount
            }).ToList();
        }
    }
}
