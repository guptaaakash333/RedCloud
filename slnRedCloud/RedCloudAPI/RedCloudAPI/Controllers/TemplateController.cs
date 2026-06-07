using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.OrganizationAdmins.Commands;
using RedCloud.Application.Features.OrganizationAdmins.Queries;
using RedCloud.Application.Features.Templates.Command;
using RedCloud.Application.Features.Templates.Queries;

namespace RedCloudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<TemplateController> _logger;

        public TemplateController(IMediator mediator, ILogger<TemplateController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("AddTemplate")]
        public async Task<ActionResult> Create([FromBody] CreateTemplateCommand createTemplate)
        {
            var response = await _mediator.Send(createTemplate);
            return Ok(response);
        }

        [HttpPut("UpdateTemplate")]
        public async Task<ActionResult> Update([FromBody] UpdateTemplateCommand updateTemplate)
        {
            var response = await _mediator.Send(updateTemplate);
            return Ok(response);
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllTemplates()
        {
            //_logger.LogInformation("GetAllOrganizationAdminList Initiated");
            var data = await _mediator.Send(new GetAllTemplateQuery());
            return Ok(data);
        }


        [HttpGet("GetDetailsById/{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetTemplateId(int id)
        {
            //_logger.LogInformation("GetOrgaAdminById initiated");
            var result = await _mediator.Send(new GetTemplateByIdQuery(id));
            if (result.Data == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpDelete("DeleteTemplate/{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteTemplate(int id)
        {
            var deletetemplate = await _mediator.Send(new DeleteTemplateCommand() { Id = id });
            if (deletetemplate == null)
            {
                return NotFound("");
            }
            return Ok("Template Deleted SuccessFully");
        }
    }
}
