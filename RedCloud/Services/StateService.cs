using Microsoft.AspNetCore.Mvc;
using MvcApiCallingService.Helpers.ApiHelper;
using RedCloud.Interfaces;
using RedCloud.ViewModel;

namespace RedCloud.Services
{
    public class StateService<T>:IStateService<T> where T : class
    {
        private readonly ILogger<StateService<T>> _logger;
        private readonly IApiClient<StateVM> _dropDown;


        public StateService(ILogger<StateService<T>> logger, IApiClient<StateVM> dropDown)
        {
            _logger = logger;
            _dropDown = dropDown;
        }

        [HttpGet]
        public async Task<IEnumerable<StateVM>> GetStatesByCountryId(int id)
        {
            _logger.LogInformation("GetStatesByCountryId Service initiated");

            string apiUrl = $"Country/{id}/states";

            var state = await _dropDown.GetListByIdAsync(apiUrl);

            _logger.LogInformation("GetStatesByCountryId Service completed");

            return state.Data;




        }
    }
}
