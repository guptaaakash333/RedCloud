using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.MessagingUsers.Queries
{
    public class MessagingUserVM
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
