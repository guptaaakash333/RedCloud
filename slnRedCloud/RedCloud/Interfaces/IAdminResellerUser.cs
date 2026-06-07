using RedCloud.Application.Features.RedCloudAdmins.Commands.CreateRedCloudAdmin;
using RedCloud.Application.Features.ResellerAdminuser.Queries;
using RedCloud.Domain.Entities;

namespace RedCloud.Interfaces
{
    public interface IAdminResellerUser
    {

        Task<int> CreateAdminResellerUserAsync(ResellerAdminUser ResellerAdminUser);

        Task UpdateAdminResellerUser(ResellerAdminUser ResellerAdminUser);


        Task<ResellerAdminUserVM> GetResellerAdminUserById(int eventId);

        Task<IEnumerable<RedCloudAdmin>> GetallResellerAdminUser();


        ////////disha////////
        ///



      // Task<IEnumerable<ReSellerAdmindto>> GetallResellerAdmin();
        Task SoftDeleteResellerAdmin(int id);
        Task<ReSellerAdmindto> GetResellerAdminById(int id);
        Task<ResellerAdminUserVM> Block(int Id);
        Task<IEnumerable<ReSellerAdmindto>> GetallResellerAdmin();
    }
}
