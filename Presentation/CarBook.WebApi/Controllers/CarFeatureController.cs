using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeatureController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeatureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCarFeaturesByCarID")]
        public async Task<IActionResult> GetCarFeaturesByCarID(int id)
        {
            var values = await _mediator.Send(new GetCarFeatureByCarIdQuery(id));
            return Ok(values);
        }

        [HttpGet("CarFeatureChangeAvailableToFalse")]
        public async Task<IActionResult> CarFeatureChangeAvailableToFalse(int id)
        {
            _mediator.Send(new UpdateCarFeatureAvailableChangeToFalseCommand(id));
            return Ok("Güncelleme Yapıldı");
        }

        [HttpGet("CarFeatureChangeAvailableToTrue")]
        public async Task<IActionResult> CarFeatureChangeAvailableToTrue(int id)
        {
            _mediator.Send(new UpdateCarFeatureAvailableChangeToTrueCommand(id));
            return Ok("Güncelleme Yapıldı");
        }
    }
}
