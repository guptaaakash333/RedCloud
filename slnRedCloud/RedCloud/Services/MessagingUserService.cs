using MvcApiCallingService.Helpers.ApiHelper;
using RedCloud.Application.Features.MessagingUsers.Commands;
using RedCloud.Application.Features.Rates.Commands;
using RedCloud.Domain.Entities;
using RedCloud.Interfaces;
using RedCloud.ViewModel;

namespace RedCloud.Services
{
    public class MessagingUserService : IMessagingUserService
    {

        private readonly IApiClient<MessagingUsersVM> _client;
        private readonly IApiClient<MessagingUsersVM> _clientTwo;
        private readonly ILogger<MessagingUserService> _logger;
        private readonly IApiClient<UpdateMessagingUserQuery> _clientThree;





        public MessagingUserService(IApiClient<MessagingUsersVM> client, IApiClient<MessagingUsersVM> clientTwo, ILogger<MessagingUserService> logger, IApiClient<UpdateMessagingUserQuery> clientThree)
        {
            _client = client;
            _logger = logger;
            _clientTwo = clientTwo;
            _clientThree = clientThree;
        }

        //AAkash
        public async Task<IEnumerable<MessagingUsersVM>> GetAllMessagingUsers()
        {
            // _logger.LogInformation("GetAllOrganizationAdmin Service initiated");
            var messagingUser = await _clientTwo.GetAllAsync("MessagingUser/GetAll");
            //_logger.LogInformation("GetAllCategories Service conpleted");
            return messagingUser.Data;
        }


        public async Task<MessagingUsersVM> GetMessagingUserById(int id)
        {
            //_logger.LogInformation($"GetOrganizationAdminDetailesById Service initiated for ID: {id}");
            var apiUrl = $"MessagingUser/GetDetailsById/{id}";     //apiurl=>controllername/id
            var response = await _clientTwo.GetByIdAsync(apiUrl);
            // _logger.LogInformation($"GetResellerAdminById Service completed for ID: {id}");
            return response.Data;
        }


        public async Task<MessagingUsersVM> BlockMessagingUser(int Id)
        {
            try
            {

                var apiUrl = $"MessagingUser/GetDetailsById/{Id}";
                var response = await _clientTwo.GetByIdAsync(apiUrl);
                var data = response.Data;
                //data.IsActive = false;
                apiUrl = $"MessagingUser/Block/{Id}";
                var updated = await _clientTwo.PutAsyncc(apiUrl, data);
                return updated.Data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> AddMessagingUser(MessagingUser messaginguser)
        {
            var response = await _clientTwo.PostAsync("MessagingUser", messaginguser);
            return response.Data > 0;
        }

        public async Task<bool> UpdateMessagingUser(UpdateMessagingUserQuery updateMessagingUserQuery)
        {
            var response = await _clientThree.PutAsync($"MessagingUser/{updateMessagingUserQuery.MessagingUserId}", updateMessagingUserQuery);
            return response.Succeeded;
        }


    }
}
