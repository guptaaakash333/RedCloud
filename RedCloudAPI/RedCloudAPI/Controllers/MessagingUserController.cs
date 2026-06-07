using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedCloud.Application.Features.MessagingUsers.Commands;
using RedCloud.Application.Features.MessagingUsers.Queries;
using RedCloud.Application.Features.OrganizationAdmins.Queries;
using RedCloud.Application.Features.OrganizationUsers.Commands;
using RedCloud.Application.Features.OrganizationUsers.Queries;
using RedCloud.Application.Features.Rates.Commands;

namespace RedCloudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagingUserController : ControllerBase
    {


        private readonly IMediator _mediator;
        private readonly ILogger<MessagingUserController> _logger;

        public MessagingUserController(IMediator mediator, ILogger<MessagingUserController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }



        [HttpGet("GetAll")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllMessagingUserList()
        {
            //_logger.LogInformation("GetAllOrganizationAdminList Initiated");
            var data = await _mediator.Send(new GetAllMessagingUserQuery());
            return Ok(data);
        }

        [HttpPut("Block/{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> BlockMessagingUser(int id)
        {
            //_logger.LogInformation("BlockReSeller Initiated");
            var blockOrganizationuser = new BlockMessagingUserCommand() { Id = id };
            await _mediator.Send(blockOrganizationuser);
            if (blockOrganizationuser == null)
            {
                return NotFound("");
            }
            return Ok("Messaging User Blocked SuccessFully");
        }

        [HttpGet("GetDetailsById/{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetMessagingUserById(int id)
        {
            //_logger.LogInformation("GetOrgaAdminById initiated");
            var result = await _mediator.Send(new GetMessagingUserByIdQuery(id));
            if (result.Data == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddMessagingUserQuery addmessaginguserquery)
        {

            try
            {
                if (addmessaginguserquery == null)
                {
                    return BadRequest("Invalid request body");
                }

                var response = await _mediator.Send(addmessaginguserquery);
                return Ok(response);
            }
            catch (Exception ex)
            {

                var errorResponse = new
                {
                    Message = "Internal server error",
                    Error = ex.Message,
                    StackTrace = ex.StackTrace
                };

                return StatusCode(500, errorResponse);
            }


        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateMessagingUserQuery updatemessaginguserquery)
        {
            try
            {
                if (updatemessaginguserquery == null || id != updatemessaginguserquery.MessagingUserId)
                {
                    return BadRequest("Invalid request body");
                }

                var response = await _mediator.Send(updatemessaginguserquery);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Internal server error",
                    Error = ex.Message,
                    StackTrace = ex.StackTrace
                };

                return StatusCode(500, errorResponse);
            }
        }
    }
}
