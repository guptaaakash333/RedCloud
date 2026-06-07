using MediatR;
using RedCloud.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.AssignNumberToUser.Commands
{
    public class AssignNumberToUserCommand: IRequest<Response<int>>
    {
        public int NumberId { get; set; }
        public List<int> MessagingUserId { get; set; }

    }
}
