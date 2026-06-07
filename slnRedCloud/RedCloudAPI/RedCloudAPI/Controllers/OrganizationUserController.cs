using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedCloud.Application.Features.OrganizationAdmins.Commands;
using RedCloud.Application.Features.OrganizationAdmins.Queries;
using RedCloud.Application.Features.OrganizationUsers.Commands;
using RedCloud.Application.Features.OrganizationUsers.Queries;

namespace RedCloudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationUserController : ControllerBase
    {
        //new

        private readonly IMediator _mediator;
        private readonly ILogger<OrganizationUserController> _logger;

        public OrganizationUserController(IMediator mediator, ILogger<OrganizationUserController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


        //Added by Akash Start
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllOrganizationUserList()
        {
            //_logger.LogInformation("GetAllOrganizationAdminList Initiated");
            var data = await _mediator.Send(new GetAllOrganizationUserQuery());
            return Ok(data);
        }


        [HttpGet("GetDetailsById/{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetOrganizationUserById(int id)
        {
            //_logger.LogInformation("GetOrgaAdminById initiated");
            var result = await _mediator.Send(new GetOrganizationUserByIdQuery(id));
            if (result.Data == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }



        //[HttpDelete("Delete/{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult> DeleteOrganizationAdmin(int id)
        //{
        //    // _logger.LogInformation("DeleteOrganizationAdmin Initiated");
        //    var deletereselleradmin = await _mediator.Send(new DeleteOrganizationAdminCommand() { Id = id });
        //    if (deletereselleradmin == null)
        //    {
        //        return NotFound("");
        //    }
        //    return Ok("Organization Admin Deleted SuccessFully");
        //}


        [HttpPut("Block/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> BlockOrganizationUser(int id)
        {
            //_logger.LogInformation("BlockReSeller Initiated");
            var blockOrganizationuser = new BlockOrganizationUserCommand() { Id = id };
            await _mediator.Send(blockOrganizationuser);
            if (blockOrganizationuser == null)
            {
                return NotFound("");
            }
            return Ok("Organization User Blocked SuccessFully");
        }


        //Added by Akash End




        [HttpPost("AddOrganizationUser")]
        public async Task<ActionResult> Create([FromBody] CreateOrganizationUserCommand createOrganizationUser)
        {
            var response = await _mediator.Send(createOrganizationUser);
            return Ok(response);
        }

        [HttpPut("UpdateOrganizationUser")]
        public async Task<ActionResult> Update([FromBody] UpdateOrganizationUserCommand updateOrganizationUser)
        {
            var response = await _mediator.Send(updateOrganizationUser);
            return Ok(response);
        }

        //[HttpGet("{id:int}", Name = "fetchOrganizationAdminById")]
        //public async Task<ActionResult> FetchOrganizationAdminById(int id)
        //{
        //    //_logger.LogInformation($"GetResellerAdminById Initiated for ID: {id}");
        //    var dto = await _mediator.Send(new OrganizationAdminQuery(id));
        //    if (dto == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(dto);
        //}
    }
}
