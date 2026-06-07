using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.OrganizationUsers.Commands
{
    public class BlockOrganizationUserCommand : IRequest<Unit>
    {
        public int Id { get; set; }


    }
}
