using MediatR;
using RedCloud.Application.Features.Carrierss;
using RedCloud.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.AssignmentType.Queries
{
    public  class GetAllAssignmentTypeListCommand: IRequest<Response<IEnumerable<AssignmentTypeVM>>>
    {
    }
}
