using Microsoft.Extensions.Logging;
using MvcApiCallingService.Helpers.ApiHelper;
using RedCloud.Application.Features.OrganizationAdmins.Queries;
using RedCloud.Domain.Entities;
using RedCloud.Interfaces;
using RedCloud.ViewModel;

namespace RedCloud.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly IApiClient<TemplateVM> _client;

        public readonly ILogger<TemplateService> _logger;


        public TemplateService(IApiClient<TemplateVM> client, ILogger<TemplateService> logger)
        {
            _client = client;
            _logger = logger;


        }
        public async Task<int> CreateTemplate(TemplateVM template)
        {
            _logger.LogInformation("CreateCategory Service initiated");
            var users = await _client.PostAsync("Template/AddTemplate", template);
            _logger.LogInformation("CreateCategory Service conpleted");
            return users.Data;
        }

        public async Task EditTemplate(TemplateVM template)
        {
            var users = await _client.PutAsync("Template/UpdateTemplate", template);
        }

        public async Task DeleteTemplate(int Id)
        {
            await _client.DeleteAsync($"Template/DeleteTemplate/{Id}");
        }

       

        public async Task<IEnumerable<TemplateVM>> GetAllTemplates()
        {
            _logger.LogInformation("GetAllOrganizationAdmin Service initiated");
            var allTemplates = await _client.GetAllAsync("Template/GetAll");
            _logger.LogInformation("GetAllCategories Service conpleted");
            return allTemplates.Data;
        }

        public async Task<TemplateVM> GetTemplateById(int id)
        {
             _logger.LogInformation("GetEventById Service initiated");
            var Event = await _client.GetByIdAsync("Template/GetDetailsById/" + id);
            _logger.LogInformation("GetEventById Service conpleted");
            return Event.Data;
        }
    }
}
