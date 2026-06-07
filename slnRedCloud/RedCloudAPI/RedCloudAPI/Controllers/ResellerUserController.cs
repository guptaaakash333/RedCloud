using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedCloud.Application.Features.OrganizationAdmins.Commands;
using RedCloud.Application.Features.ResellerUsers.Command;
using RedCloud.Application.Features.ResellerUsers.Queries;

namespace RedCloudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResellerUserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ResellerUserController> _logger;

        public ResellerUserController(IMediator mediator, ILogger<ResellerUserController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("AddResellerUser")]
        public async Task<ActionResult> Create([FromBody] CreateResellerUserCommand createResellerUserCommand)
        {
            var response = await _mediator.Send(createResellerUserCommand);
            return Ok(response);
        }



        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllResellerUserList()
        {
            //_logger.LogInformation("GetAllOrganizationAdminList Initiated");
            var data = await _mediator.Send(new GetAllResellerUserQuery());
            return Ok(data);
        }

        [HttpGet("GetDetailsById/{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetOrganizationUserById(int id)
        {
            //_logger.LogInformation("GetOrgaAdminById initiated");
            var result = await _mediator.Send(new GetResellerUserDetailsByIdQuery(id));
            if (result.Data == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpPut("Block/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> BlockOrganizationUser(int id)
        {
            //_logger.LogInformation("BlockReSeller Initiated");
            var blockOrganizationuser = new BlockResellerUserCommand() { Id = id };
            await _mediator.Send(blockOrganizationuser);
            if (blockOrganizationuser == null)
            {
                return NotFound("");
            }
            return Ok("Reseller User Blocked SuccessFully");
        }

        [HttpPut("UpdateResellerUser")]
        public async Task<ActionResult> Update([FromBody] UpdateResellerUserCommand updateResellerUser)
        {
            var response = await _mediator.Send(updateResellerUser);
            return Ok(response);
        }
    }
}
