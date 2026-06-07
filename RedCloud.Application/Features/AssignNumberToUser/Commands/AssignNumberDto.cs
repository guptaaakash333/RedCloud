using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.AssignNumberToUser.Commands
{
    public class AssignNumberDto
    {
        public int? NumberId { get; set; }
        public int? MessagingUserId { get; set; }
    }
}
