using MediatR;
using RedCloud.Application.Features.Campaigns.Queries;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.AssignNumberToUser.Queries
{
    public class GetAllAssignNumberQueries: IRequest<Response<IEnumerable<GetAllAssignNumber>>>
    {

    }
}
