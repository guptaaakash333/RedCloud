using MediatR;
using RedCloud.Application.Features.OrganizationAdmins.Queries;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Campaigns.Queries
{
    public class GetCampaignByIdQuery : IRequest<Response<CampaignDetailsVM>>
    {
        public int Id { get; set; }

        public GetCampaignByIdQuery(int id )
        {
            Id = id;
        }



    }
}
