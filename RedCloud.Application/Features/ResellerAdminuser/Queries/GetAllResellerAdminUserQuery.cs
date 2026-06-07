using MediatR;
using RedCloud.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.ResellerAdminuser.Queries
{
    public  class GetAllResellerAdminUserQuery:IRequest<Response<IEnumerable<ResellerAdminUserVM>>>
    {
    }
}
