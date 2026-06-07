using MvcApiCallingService.Helpers.ApiHelper;
using RedCloud.Application.Features.AssignNumberToUser.Commands;
using RedCloud.Domain.Entities;
using RedCloud.Interfaces;

namespace RedCloud.Services
{
    public class AssignNumberService : IAssignNumberService
    {
        private readonly IApiClient<GetAllAssignNumber> _client;            //name of Entity or viewmodel
        public readonly ILogger<GetAllAssignNumber> _logger;                //add service name

        public AssignNumberService(IApiClient<GetAllAssignNumber> client, ILogger<GetAllAssignNumber> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<int> CreateAssignNumber(AssignNumberToUserCommand command)
        {
            // _logger.LogInformation("CreateAssignNumber Service initiated");
            var result = await _client.PostAsync("AssignNumber/AssignNumberToUser", command);
            // _logger.LogInformation("Addcampaign Service completed");
            return result.Data;
        }

        public async Task<IEnumerable<GetAllAssignNumber>> GetAllAssignNumber()
        {
            //_logger.LogInformation("GetAllAssignNumber Service initiated");
            try
            {
                var numberData = await _client.GetAllAsync("AssignNumber/GetAllAssignNumberToUser");    //add u r api link this get all Async is from api helper
                return numberData.Data;
            }
            catch (Exception)
            {

                throw;
            }            //_logger.LogInformation("GetAllAssignNumber Service completed");
            
        }

        public async Task<GetAllAssignNumber> GetAssignNumberById(int id)
        {
            // _logger.LogInformation("GetAssignNumberById Service completed");
            var apiUrl = $"AssignNumber/GetAssignNumberById/{id}";                                      //apiurl=>controllername/id
            var campaignData = await _client.GetByIdAsync(apiUrl);
            //_logger.LogInformation("GetAssignNumberById Service completed");
            return campaignData.Data;
        }
    }
}
