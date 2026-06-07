using Microsoft.AspNetCore.Mvc;
using MvcApiCallingService.Helpers.ApiHelper;
using RedCloud.Application.Features.Campaigns.Queries;

//using RedCloud.Application.Features.Campaign;
using RedCloud.Interfaces;

namespace RedCloud.Services
{
    public class Campaign<T> : ICampaign<T> where T : class
    {


        private readonly ILogger<CarrierService<T>> _logger;
        private readonly IApiClient<CampaignVM> _client;


        public Campaign(ILogger<CarrierService<T>> logger, IApiClient<CampaignVM> client)
        {
            _logger = logger;

            _client = client;
        }

        public async Task<IEnumerable<CampaignVM>> GetallCampaignlist()
        {
            _logger.LogInformation("getcampaign Service initiated");
            var carrier = await _client.GetAllAsync("Campaign/all");
            _logger.LogInformation("getcampaign Service conpleted");
            return carrier.Data;

        }

      
    }
}
