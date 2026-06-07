using MvcApiCallingService.Helpers.ApiHelper;
using RedCloud.Interfaces;
using RedCloud.ViewModel;

namespace RedCloud.Services
{
    public class ResellerUserService:IResellerUserService 
    {
        private readonly IApiClient<ResellerUserVM> _client;

        public readonly ILogger<ResellerUserService> _logger;


        public ResellerUserService(IApiClient<ResellerUserVM> client, ILogger<ResellerUserService> logger)
        {
            _client = client;
            _logger = logger;


        }

        public async Task<ResellerUserVM> BlockResellerUser(int Id)
        {
            try
            {
                var apiUrl = $"ResellerUser/GetDetailsById/{Id}";//OrganizationUser/Block/{Id} Api url 
                var response = await _client.GetByIdAsync(apiUrl);
                var data = response.Data;
                data.IsActive = false;
                apiUrl = $"ResellerUser/Block/{Id}";//OrganizationUser/Block/{Id}
                var updated = await _client.PutAsyncc(apiUrl, data);
                return updated.Data;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<IEnumerable<ResellerUserVM>> GetAllResellerUser()
        {
            // _logger.LogInformation("GetAllOrganizationAdmin Service initiated");
            var OrganizationAdmin = await _client.GetAllAsync("ResellerUser/GetAll");//OrganizationUser/GetAll Api url
            //_logger.LogInformation("GetAllCategories Service conpleted");
            return OrganizationAdmin.Data;
        }

        public async Task<ResellerUserVM> GetResellerUserDetailesById(int id)
        {
            //_logger.LogInformation($"GetOrganizationAdminDetailesById Service initiated for ID: {id}");
            var apiUrl = $"ResellerUser/GetDetailsById/{id}";     //apiurl=>controllername/id  =>OrganizationUser/GetDetailsById/{id}
            var response = await _client.GetByIdAsync(apiUrl);
            // _logger.LogInformation($"GetResellerAdminById Service completed for ID: {id}");
            return response.Data;
        }

        public async Task<int> CreateResellerUser(ResellerUserVM resellerUser)
        {
            //_logger.LogInformation("CreateCategory Service initiated");
            var users = await _client.PostAsync("ResellerUser/AddResellerUser", resellerUser);//OrganizationUser/AddOrganizationUser
            //_logger.LogInformation("CreateCategory Service conpleted");
            return users.Data;
        }

        public async Task EditResellerUser(ResellerUserVM organizationAdmin)
        {
            var users = await _client.PutAsync("ResellerUser/UpdateResellerUser", organizationAdmin);
        }

    }
}
