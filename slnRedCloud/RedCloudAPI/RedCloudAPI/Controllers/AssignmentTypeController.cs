using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedCloud.Application.Features.AssignmentType.Queries;
using RedCloud.Application.Features.Types.Queries;

namespace RedCloudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AssignmentTypeController> _logger;
        public AssignmentTypeController(IMediator mediator, ILogger<AssignmentTypeController> logger)
        {
            _logger = logger;
            _mediator = mediator;

        }
        


        [HttpGet("all", Name = "GetAllAssignmentTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllAssignmentTypes()
        {
            _logger.LogInformation("GetAllAssignmentTypes Initiated");
            var dtos = await _mediator.Send(new GetAllAssignmentTypeListCommand());
            return Ok(dtos);
        }
    }
}
