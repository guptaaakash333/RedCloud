using MediatR;
using RedCloud.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.ResellerAdminuser.Queries
{
    public class ResellerAdminUserGetByIdQuery: IRequest<Response<ResellerAdminUserVM>>
    {

        public int Id { get; set; }

        
    }
}
