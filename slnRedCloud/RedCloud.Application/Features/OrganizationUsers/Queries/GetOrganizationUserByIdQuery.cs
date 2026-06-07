using MediatR;
using RedCloud.Application.Features.OrganizationAdmins.Queries;
using RedCloud.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.OrganizationUsers.Queries
{
    public class GetOrganizationUserByIdQuery : IRequest<Response<GetAllOrganizationUserVM>>
    {
        public int Id { get; set; }

        public GetOrganizationUserByIdQuery(int id)
        {
            Id = id;
        }

    }
}
