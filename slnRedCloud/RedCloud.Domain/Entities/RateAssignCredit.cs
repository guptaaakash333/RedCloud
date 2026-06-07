using RedCloud.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Domain.Entities
{
    public class RateAssignCredit : AuditableEntity
    {
        [Key]
        public int RateAssignCreditId { get; set; }
        public int OrgID { get; set; }
        public int TypeId { get; set; }
        public string InboundSMS { get; set; }
        public string OutboundSMS { get; set; }
        public string InboundMMS { get; set; }
        public string OutboundMMS { get; set; }
        public string MonthlyNumber { get; set; }
        public string Users { get; set; }
        //public List<OrganizationAdmin>? OrganizationAdmin { get; set; }
        //public List<CreditsType>? CreditsType { get; set; }
    }
}
