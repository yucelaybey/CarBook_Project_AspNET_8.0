﻿using CarBook.Application.Features.Mediator.Queries.RentACarQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentACarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentACarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetRentACarListByLocation(int LocationID,bool available)
        {
            GetRentACarQuery getRentACarQuery = new GetRentACarQuery()
            {
                LocationID = LocationID,
                Available = available
            };
            var values = await _mediator.Send(getRentACarQuery);
            return Ok(values);
        }
    }
}
