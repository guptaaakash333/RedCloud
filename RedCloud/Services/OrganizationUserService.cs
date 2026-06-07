using MvcApiCallingService.Helpers.ApiHelper;
using RedCloud.Interfaces;
using RedCloud.ViewModel;

namespace RedCloud.Services
{
    public class OrganizationUserService : IOrganizationUserService
    {

        private readonly IApiClient<OrganizationUserVM> _client;
        
        public readonly ILogger<OrganizationUserService> _logger;


        public OrganizationUserService(IApiClient<OrganizationUserVM> client, ILogger<OrganizationUserService> logger)
        {
            _client = client;
            _logger = logger;
            

        }

        public async Task<OrganizationUserVM> BlockOrganizationUser(int Id)
        {
            try
            {
                var apiUrl = $"OrganizationUser/GetDetailsById/{Id}";
                var response = await _client.GetByIdAsync(apiUrl);
                var data = response.Data;
                data.IsActive = false;
                apiUrl = $"OrganizationUser/Block/{Id}";
                var updated = await _client.PutAsyncc(apiUrl, data);
                return updated.Data;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<IEnumerable<OrganizationUserVM>> GetAllOrganizationUser()
        {
            // _logger.LogInformation("GetAllOrganizationAdmin Service initiated");
            var OrganizationAdmin = await _client.GetAllAsync("OrganizationUser/GetAll");
            //_logger.LogInformation("GetAllCategories Service conpleted");
            return OrganizationAdmin.Data;
        }

        public async Task<OrganizationUserVM> GetOrganizationUserDetailesById(int id)
        {
            //_logger.LogInformation($"GetOrganizationAdminDetailesById Service initiated for ID: {id}");
            var apiUrl = $"OrganizationUser/GetDetailsById/{id}";     //apiurl=>controllername/id
            var response = await _client.GetByIdAsync(apiUrl);
            // _logger.LogInformation($"GetResellerAdminById Service completed for ID: {id}");
            return response.Data;
        }

        public async Task<int> CreateOrganizationUser(OrganizationUserVM organizationAdmin)
        {
            //_logger.LogInformation("CreateCategory Service initiated");
            var users = await _client.PostAsync("OrganizationUser/AddOrganizationUser", organizationAdmin);
            //_logger.LogInformation("CreateCategory Service conpleted");
            return users.Data;
        }

        public async Task EditOrganizationUser(OrganizationUserVM organizationAdmin)
        {
            var users = await _client.PutAsync("OrganizationUser/UpdateOrganizationUser", organizationAdmin);
        }
    }
}
