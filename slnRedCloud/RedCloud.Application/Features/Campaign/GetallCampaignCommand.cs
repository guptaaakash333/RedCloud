using MediatR;
using RedCloud.Application.Features.ResellerAdminuser.Queries;
using RedCloud.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Campaign
{
    public  class GetallCampaignCommand: IRequest<Response<IEnumerable<CampaignVM>>>
    {
    }
}
