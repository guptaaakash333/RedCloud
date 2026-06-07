using MediatR;
using RedCloud.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.OrganizationUsers.Commands
{
    public class CreateOrganizationUserCommand : IRequest<Response<int>>
    {
        public int OrganizationUserId { get; set; }

        public string OrganizationUserFirstName { get; set; }


        public string OrganizationUserLastName { get; set; }

        public string OrganizationUserEmail { get; set; }

        public string? OrganizationUserPassword { get; set; }

        public bool IsActive { get; set; }

        public int? OrganizationAdminId { get; set; }

    }
}
