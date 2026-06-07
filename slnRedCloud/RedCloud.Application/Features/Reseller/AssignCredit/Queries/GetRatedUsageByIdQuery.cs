using MediatR;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Reseller.AssignCredit.Queries
{
    public class GetRatedUsageByIdQuery : IRequest<Response<GetRatedUsage>>
    {
        public int GetRateAssignCreditId { get; set; }

    }
}
