using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedCloud.Application.Features.Cities.Queries;
using RedCloud.Application.Features.Countries;
using RedCloud.Application.Features.States;

namespace RedCloudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CountryController> _logger;
        public CountryController(IMediator mediator, ILogger<CountryController> logger)
        {
            _logger = logger;
            _mediator = mediator;

        }
        //public IActionResult Index()
        //{
        //    return View();
        //}


        [HttpGet("all", Name = "GetAllCountry")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllCountry()
        {
            _logger.LogInformation("GetAllCountries Initiated");
            var dtos = await _mediator.Send(new GetCountryList());
            return Ok(dtos);
        }

        [HttpGet("{Id}/states", Name = "GetStateByCountryId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetStateByCountryId(int Id)
        {
            //_logger.LogInformation("GetStateByCountryId Initiated");
            //var dtos = await _mediator.Send(new GetStateListByCountryQuery());
            //return Ok(dtos);
            _logger.LogInformation("GetStateByCountryId Initiated");
            var dtos = await _mediator.Send(new GetStateListByCountryQuery { CountryId = Id });
            return Ok(dtos);
        }

        [HttpGet("{Id}/cities", Name = "GetCityByStateId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetCityByStateId(int Id)
        {
            //    _logger.LogInformation("GetCityByStateId Initiated");
            //    var dtos = await _mediator.Send(new GetCityListByStateId());
            //    return Ok(dtos);
            _logger.LogInformation("GetCityByStateId Initiated");
            var dtos = await _mediator.Send(new GetCityListByStateId { StateId = Id });
            return Ok(dtos);
        }

    }
}
