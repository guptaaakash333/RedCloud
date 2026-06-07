using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedCloud.Application.Features.Countries;
using RedCloud.Application.Features.Types.Queries;

namespace RedCloudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly ILogger<TypesController> _logger;
        public TypesController(IMediator mediator, ILogger<TypesController> logger)
        {
            _logger = logger;
            _mediator = mediator;

        }
        //public IActionResult Index()
        //{
        //    return View();
        //}


        [HttpGet("all", Name = "GetAllTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllTypes()
        {
            _logger.LogInformation("GetAllTypes Initiated");
            var dtos = await _mediator.Send(new GetallTypesCommand());
            return Ok(dtos);
        }
    }
}
