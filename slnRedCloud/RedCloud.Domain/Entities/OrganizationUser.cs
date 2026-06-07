using RedCloud.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Domain.Entities
{
    public class OrganizationUser : AuditableEntity
    {
        public int OrganizationUserId { get; set; }

        public string OrganizationUserFirstName { get; set;}


        public string OrganizationUserLastName { get; set;}

        public string OrganizationUserEmail { get; set; }

        public string? OrganizationUserPassword { get; set; }

        public bool IsActive {  get; set; } = true;

        public int OrganizationAdminId { get; set; }

        public OrganizationAdmin OrganizationAdmin { get; set; }





       
    }
}
