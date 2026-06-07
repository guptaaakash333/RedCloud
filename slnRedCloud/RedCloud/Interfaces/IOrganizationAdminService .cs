
using RedCloud.ViewModel;

namespace RedCloud.Interfaces
{
    public interface IOrganizationAdminService
    {

        //AAKASH
        Task<IEnumerable<AllOrganizationAdminVM>> GetAllOrganizationAdmin();
        Task SoftDeleteOrganizationAdmin(int id);
        Task<AllOrganizationAdminVM> GetOrganizationAdminDetailesById(int id);
        Task<AllOrganizationAdminVM> BlockOrganizationAdmin(int Id);


        //---------------------------------------
        Task<int> CreateOrganizationAdmin(OrganizationAdminVM organizationAdmin);

        Task EditOrganizationAdmin(OrganizationAdminVM organizationAdmin);

        Task<OrganizationAdminVM> GetOrganizationAdminById(int eventId);
        Task<IEnumerable<OrganizationAdminVM>> GetAllOrganizationAdmins();
    }
}
