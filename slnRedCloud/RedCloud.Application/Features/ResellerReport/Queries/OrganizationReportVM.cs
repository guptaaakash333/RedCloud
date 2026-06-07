using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.ResellerReport.Queries
{
    public class OrganizationReportVM
    {
        public string OrgName { get; set; }
        public string OrgAdminMobNo { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
    }
}
