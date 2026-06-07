using Microsoft.AspNetCore.Mvc;
using MvcApiCallingService.Helpers.ApiHelper;
using RedCloud.Interfaces;
using RedCloud.ViewModel;

namespace RedCloud.Services
{
    public class DropDownService<T> : IDropDownService<T> where T : class
    {
       
           private readonly ILogger<DropDownService<T>> _logger;
        private readonly IApiClient<CountryVM> _dropDown;


        public DropDownService(ILogger<DropDownService<T>> logger, IApiClient<CountryVM> dropDown)
        {
            _logger = logger;
            _dropDown = dropDown;
        }



        [HttpGet]
        public async Task<IEnumerable<CountryVM>> GetAllCountryList()
        {
            _logger.LogInformation("GetAllCountry Service initiated");
            var reSelleradmin = await _dropDown.GetAllAsync("Country/all");
            _logger.LogInformation("GetAllCountry Service conpleted");
            return reSelleradmin.Data;
        }
    }
    }

