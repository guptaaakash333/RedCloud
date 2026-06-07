using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Domain.Entities
{
    public class AdminInboundMessageReport
    {
        public string ResellerName { get; set; }
        public string OrgName { get; set; }
        public string OrgAdminMobNo { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
    }
}
