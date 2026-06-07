using Microsoft.AspNetCore.Mvc;
using MvcApiCallingService.Helpers.ApiHelper;
using RedCloud.Interfaces;
using RedCloud.ViewModel;

namespace RedCloud.Services
{
    public class CarrierService<T> : ICarrier<T> where T : class
    {


        private readonly ILogger<CarrierService<T>> _logger;
        private readonly IApiClient<CarrierVM> _client;


        public CarrierService(ILogger<CarrierService<T>> logger, IApiClient<CarrierVM> client)
        {
            _logger = logger;
           
            _client = client;
        }



        [HttpGet]
       
        public async Task<IEnumerable<CarrierVM>> GetAllCarriersList()
        {
            _logger.LogInformation("GetAllTypes Service initiated");
            var carrier = await _client.GetAllAsync("Carrier/all");
            _logger.LogInformation("GetAllCountry Service conpleted");
            return carrier.Data;
        }
    }
}
