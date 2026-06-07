using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedCloud.Application.Features.ResellerReport.Queries;
using RedCloud.Application.Responses;

namespace RedCloudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportApiController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReportApiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Response<IEnumerable<OrganizationReportVM>>>> GetOrganizationReport()
        {
            try
            {
                var response = await _mediator.Send(new GetOrganizationReportQuery());
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("outbound-organization-report")]
        
        public async Task<ActionResult<Response<IEnumerable<OrganizationReportVM>>>> GetOutboundOrganizationReport()
        {
            try
            {
                var response = await _mediator.Send(new GetOutboundOrganizationReportQuery());
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("All-organization-report")]

        public async Task<ActionResult<Response<IEnumerable<OrganizationReportVM>>>> GetAllOrganizationReport()
        {
            try
            {
                var response = await _mediator.Send(new GetAllOrganizationReportQuery());
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("Total-organization-report")]

        public async Task<ActionResult<Response<IEnumerable<OrganizationReportVM>>>> GetTotalOrganizationReport()
        {
            try
            {
                var response = await _mediator.Send(new GetTotalOrganizationReportQuery());
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}

