using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedCloud.Application.Features.Carrierss.Queries;
using RedCloud.Application.Features.Types.Queries;

namespace RedCloudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierController : ControllerBase
    {

       
        private readonly IMediator _mediator;
        private readonly ILogger<CarrierController> _logger;
        public CarrierController(IMediator mediator, ILogger<CarrierController> logger)
        {
            _logger = logger;
            _mediator = mediator;

        }
      
        [HttpGet("all", Name = "GetAllCarriers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllCarriers()
        {
            _logger.LogInformation("GetAllCarriers Initiated");
            var dtos = await _mediator.Send(new GetallCarrierListCommand());
            return Ok(dtos);
        }



    }
}
