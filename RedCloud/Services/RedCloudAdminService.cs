using Microsoft.AspNetCore.Mvc;
using MvcApiCallingService.Helpers.ApiHelper;
using RedCloud.Application.Features.RedCloudAdmins.Commands.CreateRedCloudAdmin;
using RedCloud.Application.Features.ResellerAdminuser.Queries;
using RedCloud.Domain.Entities;
using RedCloud.Interfaces;

namespace RedCloud.Services
{
    public class RedCloudAdminService : IRedCloudAdminService
    {

        private readonly IApiClient<RedCloudAdminVM> _client;
        public readonly ILogger<RedCloudAdminService> _logger;

        public RedCloudAdminService(IApiClient<RedCloudAdminVM> client, ILogger<RedCloudAdminService> logger)
        {
            _client = client;
            _logger = logger;
        }

        //public async Task<int> CreateAdminUser(RedCloudAdmin adminUser)
        //{
        //    //_logger.LogInformation("CreateCategory Service initiated");
        //    var users = await _client.PostAsync("AdminUser/AddAdminUser", adminUser);
        //    //_logger.LogInformation("CreateCategory Service conpleted");
        //    return users.Data;
        //}



        [HttpPost]
        public async Task EditAdminUser(RedCloudAdmin adminUser)
        {
            var users = _client.PutAsync("RedCloudAdmin/EditAdminUser", adminUser);
            //not returning anything here.
            //return users.Data;  
        }



        public async Task<RedCloudAdminVM> GetAdminUserById(int Id)
        {
            // _logger.LogInformation("GetEventById Service initiated");
            var Events = await _client.GetByIdAsync($"RedCloudAdmin/{Id}");
            //_logger.LogInformation("GetEventById Service conpleted");
            return Events.Data;
        }

        public async Task<int> CreateAdminUser(RedCloudAdmin adminUser)
        {
            //changed return type to int
            //_logger.LogInformation("CreateCategory Service initiated");
            var users = await _client.PostAsync("RedCloudAdmin/AddAdminUser", adminUser);
            //_logger.LogInformation("CreateCategory Service conpleted");
           // return a;
            return users.Data;


        }

        public async Task<IEnumerable<RedCloudAdminVM>> GetallRedCloudAdminUser()
        {
            // _logger.LogInformation("GetAllRedCloudAdmin Service initiated");
            var reSelleradmin = await _client.GetAllAsync("RedCloudAdmin/all");//add api link hehe
                                                                                      // _logger.LogInformation("GetAllRedCloudAdmin Service conpleted");
            return reSelleradmin.Data;
        }

        public async Task SoftDeleteRedCloudAdmin(int id)
        {
            _logger.LogInformation($"Soft delete initiated for ResellerAdmin with ID: {id}");

            await _client.DeleteAsync($"RedCloudAdmin/{id}");

            _logger.LogInformation($"Soft delete completed for ResellerAdmin with ID: {id}");
        }

        public async Task<RedCloudAdminVM> Block(int Id)
        {
            var apiUrl = $"RedCloudAdmin/{Id}";
            var response = await _client.GetByIdAsync(apiUrl);
            var data = response.Data;
            data.IsActive = false;
            var updated = await _client.PutAsyncc(apiUrl, data);
            return updated.Data;

        }


    }
}
