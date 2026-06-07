using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.RedCloudAdmins.Commands
{
    public class DeleteRedCloudAdminCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
