using MediatR;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.OrganizationAdmins.Queries
{
    public class OrganizationAdminQuery : IRequest<Response<OrganizationAdminVM>>
    {

        public int Id { get; set; }

        public OrganizationAdminQuery(int id)
        {
            Id = id;
        }
    }
}
