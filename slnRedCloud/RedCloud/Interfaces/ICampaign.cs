//using RedCloud.Application.Features.Campaign;
using RedCloud.Application.Features.Campaigns.Queries;

namespace RedCloud.Interfaces
{
    public interface ICampaign<T>
    {
        Task<IEnumerable<CampaignVM>> GetallCampaignlist();
    }
}
