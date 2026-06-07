using RedCloud.ViewModel;

namespace RedCloud.Interfaces
{
    public interface IOrganizationUserService
    {
        Task<IEnumerable<OrganizationUserVM>> GetAllOrganizationUser();
        //Task SoftDeleteOrganizationUser(int id);
        Task<OrganizationUserVM> GetOrganizationUserDetailesById(int id);
        Task<OrganizationUserVM> BlockOrganizationUser(int Id);

        Task<int> CreateOrganizationUser(OrganizationUserVM organizationAdmin);

        Task EditOrganizationUser(OrganizationUserVM organizationAdmin);

        
    }
}
