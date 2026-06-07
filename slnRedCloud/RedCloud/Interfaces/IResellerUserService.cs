

using RedCloud.ViewModel;

namespace RedCloud.Interfaces
{
    public interface IResellerUserService
    {


        Task<IEnumerable<ResellerUserVM>> GetAllResellerUser();
        //Task SoftDeleteOrganizationUser(int id);
        Task<ResellerUserVM> GetResellerUserDetailesById(int id);
        Task<ResellerUserVM> BlockResellerUser(int Id);

        Task<int> CreateResellerUser(ResellerUserVM organizationAdmin);

        Task EditResellerUser(ResellerUserVM organizationAdmin);

    }
}
