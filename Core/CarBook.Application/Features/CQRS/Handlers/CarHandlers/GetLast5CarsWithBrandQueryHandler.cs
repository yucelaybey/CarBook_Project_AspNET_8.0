﻿using CarBook.Application.Features.CQRS.Result.CarResult;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetLast5CarsWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetLast5CarsWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }
        public List<GetCarWithBrandQueryResult> Handle()
        {
            var values = _repository.GetLast5CarsWithBrands();
            return values.Select(x => new GetCarWithBrandQueryResult
            {
                BrandName = x.Brand.Name,
                BrandID = x.BrandID,
                BigImageUrl = x.BigImageUrl,
                CarID = x.CarID,
                Fuel = x.Fuel,
                CoverImageUrl = x.CoverImageUrl,
                Km = x.Km,
                Luggage = x.Luggage,
                Model = x.Model,
                Seat = x.Seat,
                Transmission = x.Transmission

            }).ToList();
        }
    }
}
