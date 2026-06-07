using MediatR;
using RedCloud.Application.Features.OrganizationAdmins.Queries;
using RedCloud.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.ResellerUsers.Queries
{
    public class GetResellerUserDetailsByIdQuery : IRequest<Response<ResellerUserVM>>
    {

        public int Id { get; set; }
        public GetResellerUserDetailsByIdQuery(int id)
        {
            Id = id;
            
        }
    }
}
