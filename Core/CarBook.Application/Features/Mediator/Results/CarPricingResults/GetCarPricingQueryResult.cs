﻿
namespace CarBook.Application.Features.Mediator.Results.CarPricingResults
{
    public class GetCarPricingQueryResult
    {
        public int CarID { get; set; }
        public int CarPricingId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Amount { get; set; }
        public string CoverImageUrl { get; set; } 
    }
}
