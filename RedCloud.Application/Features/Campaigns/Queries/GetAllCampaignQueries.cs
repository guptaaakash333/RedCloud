using MediatR;
using RedCloud.Application.Features.RedCloudAdmins.Commands.CreateRedCloudAdmin;
using RedCloud.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Campaigns.Queries
{
    public class GetAllCampaignQueries : IRequest<Response<IEnumerable<CampaignVM>>>
    {
    }
}
