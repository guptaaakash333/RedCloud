using RedCloud.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Domain.Entities
{
    public class Role : AuditableEntity
    {
        [Key]
        public int RoleId { get; set; }

        public string RoleName { get; set; }

    }
}
