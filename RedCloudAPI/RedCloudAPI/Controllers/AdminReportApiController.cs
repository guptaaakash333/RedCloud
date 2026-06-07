using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedCloud.Application.Features.AdminReport.Queries;
using RedCloud.Application.Features.ResellerReport.Queries;
using RedCloud.Application.Responses;

namespace RedCloudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminReportApiController : ControllerBase
    {

        private readonly IMediator _mediator;

        public AdminReportApiController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("outbound-Reseller-report")]
        public async Task<ActionResult<Response<IEnumerable<ResellerReportVM>>>> GetOutboundResellerReport()
        {
            try
            {
                var response = await _mediator.Send(new GetOutboundResellerReportQuery());
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("Inbound-Reseller-report")]
        public async Task<ActionResult<Response<IEnumerable<ResellerReportVM>>>> GetInboundResellerReport()
        {
            try
            {
                var response = await _mediator.Send(new GetInboundResellerReportQuery());
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("Full-Reseller-report")]
        public async Task<ActionResult<Response<IEnumerable<ResellerReportVM>>>> GetFullResellerReport()
        {
            try
            {
                var response = await _mediator.Send(new GetFullResellerReportQuery());
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("Total-Reseller-report")]

        public async Task<ActionResult<Response<IEnumerable<ResellerReportVM>>>> GetTotalResellerReport()
        {
            try
            {
                var response = await _mediator.Send(new GetTotalResellerReportQuery());
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
