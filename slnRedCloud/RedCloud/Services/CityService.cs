using MvcApiCallingService.Helpers.ApiHelper;
using RedCloud.Interfaces;
using RedCloud.ViewModel;

namespace RedCloud.Services
{
    public class CityService  <T>: ICityService<T> where T : class

    {
        private readonly ILogger<StateService<T>> _logger;
        private readonly IApiClient<CityVM> _dropDown;


        public CityService(ILogger<StateService<T>> logger, IApiClient<CityVM> dropDown)
        {
            _logger = logger;
            _dropDown = dropDown;
        }

        public async Task<IEnumerable<CityVM>> GetCityByStateId(int Id)
        {
            _logger.LogInformation("GetStatesByCountryId Service initiated");

            string apiUrl = $"Country/{Id}/cities";

            var cities = await _dropDown.GetListByIdAsync(apiUrl);

            _logger.LogInformation("GetStatesByCountryId Service completed");

            return cities.Data;
        }

    }
}