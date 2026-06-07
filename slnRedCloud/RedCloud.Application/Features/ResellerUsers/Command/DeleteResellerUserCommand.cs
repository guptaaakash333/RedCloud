using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.ResellerUsers.Command
{
    public class DeleteResellerUserCommand:IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
