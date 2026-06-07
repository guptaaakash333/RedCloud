using RedCloud.ViewModel;

namespace RedCloud.Interfaces
{
    public interface ITemplateService
    {
        Task<IEnumerable<TemplateVM>> GetAllTemplates();
        
        Task<TemplateVM> GetTemplateById(int id);
        Task DeleteTemplate(int Id);

        Task<int> CreateTemplate(TemplateVM template);

        Task EditTemplate(TemplateVM template);
    }
}
