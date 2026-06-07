using RedCloud.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Domain.Entities
{
    public class ResellerUser:AuditableEntity
    {

        public int ResellerUserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string? Password { get; set; }

        public int ? ResellerAdminUserId { get; set; }

        public virtual ResellerAdminUser? ResellerAdminUser { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
