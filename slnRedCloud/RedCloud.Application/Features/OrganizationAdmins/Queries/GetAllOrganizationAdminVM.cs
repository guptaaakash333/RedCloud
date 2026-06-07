using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.OrganizationAdmins.Queries
{
    public class GetAllOrganizationAdminVM
    {

        public int OrgID { get; set; }

        public string OrgName { get; set; }

        public string EIN { get; set; }

        public string OrgAdminEmail { get; set; }

        public bool IsActive { get; set; }

    }
}
