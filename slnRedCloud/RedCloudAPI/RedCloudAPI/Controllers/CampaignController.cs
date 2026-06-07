using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedCloud.Application.Features.Campaigns;
using RedCloud.Application.Features.Campaigns.Commands;
using RedCloud.Application.Features.Campaigns.Queries;
using RedCloud.Application.Features.RedCloudAdmins.Queries;
using RedCloud.Application.Features.ResellerAdminuser.Commands;
//using RedCloud.Application.Features.Campaign;
using RedCloud.Application.Features.Carrierss.Queries;

namespace RedCloudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {


        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        //public CampaignController(IMediator mediator, ILogger<RedCloudAdminController> logger)
       // private readonly ILogger<CampaignController> _logger;
        public CampaignController(IMediator mediator, ILogger<CampaignController> loggerr, ILogger<RedCloudAdminController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("AddCampaign")]
        public async Task<ActionResult> Create([FromBody] CreateCampaignCommand createCampaignCommand)
        {
            var response = await _mediator.Send(createCampaignCommand);
            return Ok(response);
        }


        [HttpGet("GetCampaignById/{id}")]
        public async Task<ActionResult> GetCampaignById(int id)
        {
            var campaignDetails = await _mediator.Send(new GetCampaignByIdQuery(id));
            if(campaignDetails.Data == null)
            {
                return NotFound(campaignDetails);
            }
            return Ok(campaignDetails);
        }































        //Soham


        [HttpGet("all")]
        public async Task<ActionResult> GetAllCampaign()
        {
            try
            {
                var response = await _mediator.Send(new GetAllCampaignQueries());
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching admin user by Id");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }


        }

        [HttpDelete("{id}", Name = "DeleteCampaigns")]
        public async Task<ActionResult> DeleteCampain(int id)
        {
            _logger.LogInformation("DeleteResellerAdmin Initiated");
            var campaign = new DeleteCampaignByIdCommand() { CampaignId = id };
            await _mediator.Send(campaign);

            return Ok("Campaign Deleted SuccessFully");
        }







        //[HttpGet("all", Name = "Getallcampaign")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult> Getallcampaign()
        //{
           
        //    _logger.LogInformation("Getallcampaign Initiated");
        //    var dtos = await _mediator.Send(new GetallCampaignCommand());
        //    return Ok(dtos);
        //}



    }
}
