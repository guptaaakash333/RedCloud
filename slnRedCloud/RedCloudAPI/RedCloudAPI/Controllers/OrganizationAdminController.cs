using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedCloud.Application.Features.OrganizationAdmins.Commands;
using RedCloud.Application.Features.OrganizationAdmins.Queries;
using RedCloud.Application.Features.ResellerAdminuser.Queries;


namespace RedCloudAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   
    public class OrganizationAdminController : ControllerBase
    {
        //new

        private readonly IMediator _mediator;
        private readonly ILogger<OrganizationAdminController> _logger;

        public OrganizationAdminController(IMediator mediator, ILogger<OrganizationAdminController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


        //Added by Akash Start
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllOrganizationAdminList()
        {
            //_logger.LogInformation("GetAllOrganizationAdminList Initiated");
            var data = await _mediator.Send(new GetAllOrganizationAdminQuery());
            return Ok(data);
        }


        [HttpGet("GetDetailsById/{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetOrganizationAdminDetailsById(int id)
        {
            //_logger.LogInformation("GetOrgaAdminById initiated");
            var result = await _mediator.Send(new GetOrganizationAdminDetailsQuery(id));
            if (result.Data == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }



        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteOrganizationAdmin(int id)
        {
            // _logger.LogInformation("DeleteOrganizationAdmin Initiated");
            var deletereselleradmin = await _mediator.Send(new DeleteOrganizationAdminCommand() { Id = id });
            if(deletereselleradmin == null)
            {
                return NotFound("");
            }
            return Ok("Organization Admin Deleted SuccessFully");
        }


        [HttpPut("Block/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> BlockOrganizationAdmin(int id)
        {
            //_logger.LogInformation("BlockReSeller Initiated");
            var blockOrganizationadmin = new BlockOrganizationAdminCommand() { Id = id };
            await _mediator.Send(blockOrganizationadmin);
            if(blockOrganizationadmin == null)
            {
                return NotFound("");
            }
            return Ok("Organization Admin Blocked SuccessFully");
        }


        //Added by Akash End




        [HttpPost("AddOrganizationAdmin")]
        public async Task<ActionResult> Create([FromBody] CreateOrganizationAdminCommand createOrganizationAdmin)
        {
            var response = await _mediator.Send(createOrganizationAdmin);
            return Ok(response);
        }

        [HttpPut("UpdateOrganizationAdmin")]
        public async Task<ActionResult> Update([FromBody] UpdateOrganizationAdminCommand updateOrganizationAdmin)
        {
            var response = await _mediator.Send(updateOrganizationAdmin);
            return Ok(response);
        }

        [HttpGet("{id:int}", Name = "fetchOrganizationAdminById")]
        public async Task<ActionResult> FetchOrganizationAdminById(int id)
        {
            //_logger.LogInformation($"GetResellerAdminById Initiated for ID: {id}");
            var dto = await _mediator.Send(new OrganizationAdminQuery(id));
            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        //[HttpGet("GetAll")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult> GetAllOrganizationAdminList()
        //{
        //    //_logger.LogInformation("GetAllOrganizationAdminList Initiated");
        //    var data = await _mediator.Send(new GetAllOrganizationAdminQuery());
        //    return Ok(data);
        //}
    }
}

