using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedCloud.Application.Features.ResellerAdminuser.Commands;
using RedCloud.Application.Features.ResellerAdminuser.Queries;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using static RedCloud.Application.Features.ResellerAdminuser.Commands.BlockResellerAdminCommand;

namespace RedCloudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResellerAdminUserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        public ResellerAdminUserController(IMediator mediator, ILogger<ResellerAdminUserController> logger)
        {
            _logger = logger;
            _mediator = mediator;

        }

        [HttpGet("all", Name = "GetAllResellerAdminList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllResellerAdminList()
        {
            _logger.LogInformation("GetAllResellerAdmin Initiated");
            var dtos = await _mediator.Send(new GetAllResellerAdminUserQuery());
            return Ok(dtos);
        }



        

        [HttpPost(Name = "AddResellerAdmin")]
        public async Task<ActionResult> Create([FromBody] CreateResellerAdminUserCommand CreateResellerAdminCommand)
        {
            var response = await _mediator.Send(CreateResellerAdminCommand);

            return Ok(response);
        }

        //[HttpPut("UpdateResellerAdmin")]
        //public async Task<ActionResult> Update([FromBody] UpdateResellerAdminUserCommand updateResellerAdmin)
        //{
        //    var response = await _mediator.Send(updateResellerAdmin);
        //    return Ok(response);
        //}

        //[HttpGet("{id}")]

        //public async Task<ActionResult> FetchResellerAdminUserById(int id)//changes the code
        //{

        //    //_logger.LogInformation($"GetResellerAdminById Initiated for ID: {id}");
        //    var dto = await _mediator.Send(new ResellerAdminUserGetByIdQuery() { Id = id});
        //    if (dto == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(dto);
        //}

        [HttpDelete("{id}", Name = "DeleteResellerAdmin")]
        public async Task<ActionResult> DeleteResellerAdmin(int id)
        {
            _logger.LogInformation("DeleteResellerAdmin Initiated");
            var deletereselleradmin = new DeleteReSellerAdminCommand() { Id = id };
            await _mediator.Send(deletereselleradmin);

            return Ok("ReSeller Admin Deleted SuccessFully");
        }


        //[HttpGet("{id}", Name = "GetResellerAdminById")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult> GetResellerAdminById(int id)
        //{
        //    _logger.LogInformation($"GetResellerAdminById Initiated for ID: {id}");
        //    var dto = await _mediator.Send(new GetReSellerAdminByIdQuery(id));
        //    if (dto == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(dto);
        //}

        [HttpGet("{Id:int}", Name = "GetResellerAdminById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Response<ReSellerAdmindto>>> GetResellerAdminById(int Id)
        {
            //_logger.LogInformation("GetResellerAdminById initiated");
            var result = await _mediator.Send(new GetReSellerAdminByIdQuery(Id));

            if (result.Data == null)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpPut("{id}", Name = "BlockReSeller")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> BlockReSeller(int id)
        {
            //_logger.LogInformation("BlockReSeller Initiated");
            var blockeselleradmin = new BlockReSellerAdminCommand() { Id = id };
            await _mediator.Send(blockeselleradmin);

            return Ok("ReSeller Admin Blocked SuccessFully");
        }


    }
}
