using RedCloud.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Domain.Entities
{
    public class RedCloudAdmin : AuditableEntity
    {

        [Key]
        public int RedCloudAdminUserId { get; set; }


        public string FirstName { get; set; }


        public string LastName { get; set; }


        public string Email { get; set; }


        public string MobileNumber { get; set; }


        public string? Password { get; set; }



        public bool IsActive { get; set; }=true;

        public int? ResellerAdminUserId { get; set; }
        public virtual ResellerAdminUser? ResellerAdminUsers { get; set; }




    }
}
