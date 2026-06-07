using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedCloud.Application.Features.RedCloudAdmins.Commands;
using RedCloud.Application.Features.RedCloudAdmins.Commands.CreateRedCloudAdmin;
using RedCloud.Application.Features.RedCloudAdmins.Queries;
using RedCloud.Application.Features.ResellerAdminuser.Commands;
using static RedCloud.Application.Features.ResellerAdminuser.Commands.BlockResellerAdminCommand;

namespace RedCloudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedCloudAdminController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        public RedCloudAdminController(IMediator mediator, ILogger<RedCloudAdminController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpPost("AddAdminUser")]
        public async Task<ActionResult> Create([FromBody] CreateRedCloudAdminCommand CreateAdminUserCommand)
        {
            try
            {

                var response = await _mediator.Send(CreateAdminUserCommand);
                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPut("EditAdminUser")]
        public async Task<ActionResult> Update([FromBody] EditRedCloudAdminCommand EditAdminUserCommand)
        {
            var response = await _mediator.Send(EditAdminUserCommand);
            return Ok(response);
        }


        [HttpGet("{Id}")]
        public async Task<ActionResult> GetAdminUserById(int Id)
        {
            try
            {
                var response = await _mediator.Send(new GetRedCloudAdminByIdQuery { RedCloudAdminUserId = Id });
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching admin user by Id");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var response = await _mediator.Send(new GetAllRedCloudAdminQuery() );
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching admin user by Id");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpDelete("{id}", Name = "DeleteRedCloudAdmin")]
        public async Task<ActionResult> DeleteRedCloudAdmin(int id)
        {
            _logger.LogInformation("DeleteRedCloudAdmin Initiated");
            var deleteredcloudadmin = new DeleteRedCloudAdminCommand() { Id = id };
            await _mediator.Send(deleteredcloudadmin);

            return Ok("ReSeller Admin Deleted SuccessFully");
        }

        ///
        [HttpPut("{id}", Name = "BlockRedCloudAdmin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> BlockRedCloudAdmin(int id)
        {
            _logger.LogInformation("BlockReSeller Initiated");
            var blockeselleradmin = new BlockRedCloudAdminCommand() { Id = id };
            await _mediator.Send(blockeselleradmin);

            return Ok("ReSeller Admin Blocked SuccessFully");
        }

    }
}
