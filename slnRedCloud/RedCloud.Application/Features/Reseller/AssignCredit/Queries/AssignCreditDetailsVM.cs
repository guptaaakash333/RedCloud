using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Reseller.AssignCredit.Queries
{
    public class AssignCreditDetailsVM
    {
        [Key]
        public int GetRateAssignCreditId { get; set; }
        public string? OrgName { get; set; }
        public string? TypeName { get; set; }
        public string InboundSMS { get; set; }
        public string OutboundSMS { get; set; }
        public string InboundMMS { get; set; }
        public string OutboundMMS { get; set; }
        public string MonthlyNumber { get; set; }
        public string Users { get; set; }
    }
}
