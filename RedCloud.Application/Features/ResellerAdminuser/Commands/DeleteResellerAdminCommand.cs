using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.ResellerAdminuser.Commands
{
    public class DeleteReSellerAdminCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}

