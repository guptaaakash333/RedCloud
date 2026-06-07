using MediatR;
using RedCloud.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.MessagingUsers.Commands
{
    public class UpdateMessagingUserQuery : IRequest<Response<Unit>>
    {
        public int MessagingUserId { get; set; }
        public string MessagingUserFirstName { get; set; }
        public string MessagingUserLastName { get; set; }
        public string MessagingUserEmail { get; set; }
        public string AssignedNumber { get; set; }
        public string? MessagingUserType { get; set; }

        public bool IsActive { get; set; }
    }
}
