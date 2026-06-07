using MediatR;
using RedCloud.Application.Features.Campaigns.Queries;
using RedCloud.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Reseller.AssignCredit.Queries
{
    public class GetAssignCreditByIdQuery: IRequest<Response<AssignCreditDetailsVM>>
    {
        public int GetRateAssignCreditId { get; set; }
    }
}
