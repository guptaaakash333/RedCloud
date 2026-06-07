using Microsoft.AspNetCore.Mvc;
using MvcApiCallingService.Helpers.ApiHelper;
using RedCloud.Application.Features.RedCloudAdmins.Commands.CreateRedCloudAdmin;
using RedCloud.Application.Features.ResellerAdminuser.Queries;
using RedCloud.Domain.Entities;
using RedCloud.Interfaces;

namespace RedCloud.Services
{
    public class AdminResellerUserService : IAdminResellerUser

    { 
        private readonly IApiClient<ResellerAdminUserVM> _client;//name of Entity or viewmodel
    public readonly ILogger<AdminResellerUserService> _logger;//add service name
    private readonly IApiClient<RedCloudAdmin> _adminuser;
        private readonly IApiClient<ReSellerAdmindto> _adminuserd;


        public AdminResellerUserService(IApiClient<ResellerAdminUserVM> client, ILogger<AdminResellerUserService> logger, IApiClient<RedCloudAdmin> adminuser, IApiClient<ReSellerAdmindto> adminuserd)//first one is entity and is service
        {
            _client = client;
            _logger = logger;
            _adminuser = adminuser;
            _adminuserd = adminuserd;
        }


        public async  Task<int> CreateAdminResellerUserAsync(ResellerAdminUser ResellerAdminUser)
        {
            //_logger.LogInformation("CreateCategory Service initiated");
            var users = await _client.PostAsync("ResellerAdminUser", ResellerAdminUser);//add api link and entity 

            //_logger.LogInformation("CreateCategory Service conpleted");
            return users.Data;
        }

        public async Task<IEnumerable<RedCloudAdmin>> GetallResellerAdminUser()
        {
           // _logger.LogInformation("GetAllRedCloudAdmin Service initiated");
            var reSelleradmin = await _adminuser.GetAllAsync("ResellerAdminUser/all");//add api link hehe
           // _logger.LogInformation("GetAllRedCloudAdmin Service conpleted");
            return reSelleradmin.Data;
        }

        public async Task<ResellerAdminUserVM> GetResellerAdminUserById(int eventId)
        {
            // _logger.LogInformation("GetEventById Service initiated");
            var Events = await _client.GetByIdAsync("ResellerAdmin/" + eventId);
            //_logger.LogInformation("GetEventById Service conpleted");
            return Events.Data;
        }

        public async Task UpdateAdminResellerUser(ResellerAdminUser ResellerAdminUser)
        {
          await   _client.PutAsync("ResellerAdmin/UpdateResellerAdmin", ResellerAdminUser);//
            //return users.Data;
        }

        /////disha
        ///

        [HttpGet]
        public async Task<IEnumerable<ReSellerAdmindto>> GetallResellerAdmin()
        {
            _logger.LogInformation("GetAllCategories Service initiated");
            var reSelleradmin = await _adminuserd.GetAllAsync("ResellerAdminUser/all");
            _logger.LogInformation("GetAllCategories Service conpleted");
            return reSelleradmin.Data;
        }




        //public async Task<ResellerAdminVM> GetResellerAdminById(int id)
        //{
        //    // Ensure the id is properly inserted into the URL
        //    var apiUrl = $"ReSellerAdmin/{id}";
        //    var response = await _client.GetByIdAsync(apiUrl);
        //    return response.Data;
        //}

        public async Task<ReSellerAdmindto> GetResellerAdminById(int id)
        {
            _logger.LogInformation($"GetResellerAdminById Service initiated for ID: {id}");
            var apiUrl = $"ResellerAdminUser/{id}";//apiurl=>controllername/id
            var response = await _adminuserd.GetByIdAsync(apiUrl);
            _logger.LogInformation($"GetResellerAdminById Service completed for ID: {id}");
            return response.Data;
        }


        public async Task SoftDeleteResellerAdmin(int id)
        {
            _logger.LogInformation($"Soft delete initiated for ResellerAdmin with ID: {id}");

            await _client.DeleteAsync($"ResellerAdminUser/{id}");

            _logger.LogInformation($"Soft delete completed for ResellerAdmin with ID: {id}");
        }

        public async Task<ResellerAdminUserVM> Block(int Id)
        {
            var apiUrl = $"ResellerAdminUser/{Id}";
            var response = await _client.GetByIdAsync(apiUrl);
            var data = response.Data;
            data.IsActive = false;
            var updated = await _client.PutAsyncc(apiUrl, data);
            return updated.Data;

        }

      

       
    }
}
