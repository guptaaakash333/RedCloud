using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedCloud.Application.Features.ResellerAdminuser.Commands;
using RedCloud.Application.Features.ResellerAdminuser.Queries;

namespace RedCloudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResellerAdminController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        public ResellerAdminController(IMediator mediator, ILogger<ResellerAdminUserController> logger)
        {
            _logger = logger;
            _mediator = mediator;

        }

        [HttpPut("UpdateResellerAdmin")]
        public async Task<ActionResult> Update([FromBody] UpdateResellerAdminUserCommand updateResellerAdmin)
        {
            var response = await _mediator.Send(updateResellerAdmin);
            return Ok(response);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult> FetchResellerAdminUserById(int id)//changes the code
        {

            //_logger.LogInformation($"GetResellerAdminById Initiated for ID: {id}");
            var dto = await _mediator.Send(new ResellerAdminUserGetByIdQuery() { Id = id });
            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

    }
}
