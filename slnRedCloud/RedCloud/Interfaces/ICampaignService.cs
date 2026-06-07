using RedCloud.Application.Features.RedCloudAdmins.Commands.CreateRedCloudAdmin;
using RedCloud.ViewModel;

namespace RedCloud.Interfaces
{
    public interface ICampaignService
    {

        Task<IEnumerable<CampaignVM>> GetallCampaign();


        Task SoftDeleteCampaign(int id);

        //Added by ~A.G
        Task<int> CreateCampaign(CampaignVM campaign);

        Task<CampaignDetailsVM> GetCampaign(int id);


    }
}
