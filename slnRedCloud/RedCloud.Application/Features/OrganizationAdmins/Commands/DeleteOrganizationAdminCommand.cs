using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.OrganizationAdmins.Commands
{
    public class DeleteOrganizationAdminCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
