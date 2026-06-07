using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedCloud.Application.Features.Account.Queries;
using RedCloud.Application.Features.OrganizationAdmins.Commands;
using RedCloud.Application.Features.Reseller.AssignCredit.Commands;
using RedCloud.Application.Features.Reseller.AssignCredit.Queries;
using RedCloud.Application.Models.Mail;

namespace RedCloudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResellerAssignCreditController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ResellerAssignCreditController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllAssignCredit")]
        public async Task<IActionResult> GetAllAssignCreditList()
        {
            var response = await _mediator.Send(new GetAllAssignCreditQuery());
            return Ok(response);
        }


        [HttpGet("GetOrganizationList")]
        public async Task<IActionResult> GetOrganizationList()
        {
            //var query = new GetOrganizationQuery();
            //var result = await _mediator.Send(query);

            var response = await _mediator.Send(new GetOrganizationQuery());
            return Ok(response);
        }
        [HttpGet("GetCreditList")]
        public async Task<IActionResult> GetCreditList()
        {
            var query = new GetTypeQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpPost("AddRate")]
        public async Task<ActionResult> Create([FromBody] AddRateCommand model)
        {
            var response = await _mediator.Send(model);
            return Ok(response);
        }

        [HttpGet("GetRateById/{Id}")]
        public async Task<IActionResult> GetRateById(int Id)
        {
            try
            {
                var response = await _mediator.Send(new GetRateByIdQuery { RateAssignCreditId = Id });
                if (response != null)
                {
                    return Ok(response);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes

                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPut("EditRate")]
        public async Task<ActionResult> Update([FromBody] EditRateCommand model)
        {
            var response = await _mediator.Send(model);
            return Ok(response);
        }

        [HttpGet("GetAssignCreditById/{Id}")]
        public async Task<IActionResult> GetAssignCreditById(int Id)
        {
            var assignCredit = await _mediator.Send(new GetAssignCreditByIdQuery { GetRateAssignCreditId = Id });
            if (assignCredit.Data != null)
            {
                return Ok(assignCredit);
            }
            return NotFound(assignCredit);
        }


        [HttpGet("GetRatedUsageById/{Id}")]
        public async Task<IActionResult> GetRatedUsageById(int Id)
        {
            var assignCredit = await _mediator.Send(new GetRatedUsageByIdQuery { GetRateAssignCreditId = Id });
            if (assignCredit.Data != null)
            {
                return Ok(assignCredit);
            }
            return NotFound(assignCredit);
        }





    }
}
