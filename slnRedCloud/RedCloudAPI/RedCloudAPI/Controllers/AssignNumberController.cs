using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedCloud.Application.Features.AssignNumberToUser.Commands;
using RedCloud.Application.Features.AssignNumberToUser.Queries;
using RedCloud.Application.Features.Numbers.Commands;

namespace RedCloudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class AssignNumberController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public AssignNumberController(IMediator mediator, ILogger<AssignNumberController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


        [HttpPost("AssignNumberToUser")]
        public async Task<ActionResult> crate([FromForm] AssignNumberToUserCommand assignNumberCommand)
        {
            var response = await _mediator.Send(assignNumberCommand);
            return Ok(response);
        }

        [HttpGet("GetAllAssignNumberToUser")]
        public async Task<ActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllAssignNumberQueries() );
            return Ok(response);
        }

        [HttpGet("GetAssignNumberById/{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var response = await _mediator.Send(new GetAssignNumberByIdQueries(id));
            return Ok(response);    
        }
    }
}
