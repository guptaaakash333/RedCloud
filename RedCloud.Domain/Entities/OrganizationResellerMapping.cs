using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Domain.Entities
{
    public class OrganizationResellerMapping
    {
        public int Id { get; set; }

        public int OrganizationAdminId { get; set;}
        public OrganizationAdmin OrganizationAdmin { get; set;}

        public int ResellerAdminUserId { get; set; }
        public ResellerAdminUser ResellerAdminUser { get; set; }

    }
}
