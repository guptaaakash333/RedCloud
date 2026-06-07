using MvcApiCallingService.Helpers.ApiHelper;
using RedCloud.Interfaces;
using RedCloud.ViewModel;

namespace RedCloud.Services
{
    public class OrganizationAdminService : IOrganizationAdminService
    {
        private readonly IApiClient<OrganizationAdminVM> _client;
        private readonly IApiClient<AllOrganizationAdminVM> _clientTwo;
        public readonly ILogger<OrganizationAdminService> _logger;


        public OrganizationAdminService(IApiClient<OrganizationAdminVM> client, IApiClient<AllOrganizationAdminVM> clientTwo, ILogger<OrganizationAdminService> logger)
        {
            _client = client;
            _logger = logger;
            _clientTwo = clientTwo;

        }

        //AAkash
        public async Task<IEnumerable<AllOrganizationAdminVM>> GetAllOrganizationAdmin()
        {
            // _logger.LogInformation("GetAllOrganizationAdmin Service initiated");
            var OrganizationAdmin = await _clientTwo.GetAllAsync("OrganizationAdmin/GetAll");
            //_logger.LogInformation("GetAllCategories Service conpleted");
            return OrganizationAdmin.Data;
        }


        public async Task<AllOrganizationAdminVM> GetOrganizationAdminDetailesById(int id)
        {
            //_logger.LogInformation($"GetOrganizationAdminDetailesById Service initiated for ID: {id}");
            var apiUrl = $"OrganizationAdmin/GetDetailsById/{id}";     //apiurl=>controllername/id
            var response = await _clientTwo.GetByIdAsync(apiUrl);
            // _logger.LogInformation($"GetResellerAdminById Service completed for ID: {id}");
            return response.Data;
        }


        public async Task<AllOrganizationAdminVM> BlockOrganizationAdmin(int Id)
        {
            try
            {
                    
                var apiUrl = $"OrganizationAdmin/GetDetailsById/{Id}";
                var response = await _clientTwo.GetByIdAsync(apiUrl);
                var data = response.Data;
                data.IsActive = false;
                apiUrl = $"OrganizationAdmin/Block/{Id}";
                var updated = await _clientTwo.PutAsyncc(apiUrl, data);
                return updated.Data;
            }
            catch (Exception)
            {

                throw;
            }
        }



        public async Task SoftDeleteOrganizationAdmin(int id)
        {
            // _logger.LogInformation($"Soft delete initiated for ResellerAdmin with ID: {id}");

            await _clientTwo.DeleteAsync($"OrganizationAdmin/Delete/{id}");

            //_logger.LogInformation($"Soft delete completed for ResellerAdmin with ID: {id}");
        }

        //-------------------------------------
        public async Task<int> CreateOrganizationAdmin(OrganizationAdminVM organizationAdmin)
        {
            //_logger.LogInformation("CreateCategory Service initiated");
            var users = await _client.PostAsync("OrganizationAdmin/AddOrganizationAdmin", organizationAdmin);
            //_logger.LogInformation("CreateCategory Service conpleted");
            return users.Data;
        }

        public async Task EditOrganizationAdmin(OrganizationAdminVM organizationAdmin)
        {

            var users = await _client.PutAsync("OrganizationAdmin/UpdateOrganizationAdmin", organizationAdmin);
            //return users.Data;

        }

        public async Task<OrganizationAdminVM> GetOrganizationAdminById(int eventId)
        {
            // _logger.LogInformation("GetEventById Service initiated");
            var Events = await _client.GetByIdAsync("OrganizationAdmin/" + eventId);
            //_logger.LogInformation("GetEventById Service conpleted");
            return Events.Data;
        }

        public async  Task<IEnumerable<OrganizationAdminVM>> GetAllOrganizationAdmins()
        {
            // _logger.LogInformation("GetAllOrganizationAdmin Service initiated");
            var OrganizationAdmin = await _client.GetAllAsync("OrganizationAdmin/GetAll");
            //_logger.LogInformation("GetAllCategories Service conpleted");
            return OrganizationAdmin.Data;
        }
    }
    }

