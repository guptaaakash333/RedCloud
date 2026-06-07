using Microsoft.AspNetCore.Mvc;
using MvcApiCallingService.Helpers.ApiHelper;
using RedCloud.Interfaces;
using RedCloud.ViewModel;

namespace RedCloud.Services
{
    public class TypeService<T> : IType<T> where T : class
    {


        private readonly ILogger<TypeService<T>> _logger;
        private readonly IApiClient<TypesVM> _dropDown;


        public TypeService(ILogger<TypeService<T>> logger, IApiClient<TypesVM> dropDown)
        {
            _logger = logger;
            _dropDown = dropDown;
        }



        [HttpGet]
        public async Task<IEnumerable<TypesVM>> GetAllTypesList()
        {
            _logger.LogInformation("GetAllTypes Service initiated");
            var reSelleradmin = await _dropDown.GetAllAsync("Types/all");
            _logger.LogInformation("GetAllCountry Service conpleted");
            return reSelleradmin.Data;
        }
    }
}
