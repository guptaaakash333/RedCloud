using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Rates.Queries
{
    public class RateDetailVM
    {
        public int RateId { get; set; }

        [Display(Name = "Reseller Name")]

        [ForeignKey("ResellerAdminUser")]
        public int ResellerAdminUserId { get; set; }


        public string ResellerName { get; set; }

        [Display(Name = "Monthly Number")]
        public int MonthlyNumber { get; set; }

        [Display(Name = "Users")]
        public int Users { get; set; }

        public int InboundSMS { get; set; }
        public int OutboundSMS { get; set; }

        public int InboundMMS { get; set; }


        public int OutboundMMS { get; set; }

        public string Type { get; set; } = "Postpaid/Unlimited";
    }
}
