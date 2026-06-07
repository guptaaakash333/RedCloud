using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedCloud.Domain.Common;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RedCloud.Domain.Entities
{
    public class Rate : AuditableEntity
    {
        [Key]

        public int RateId { get; set; }

        [Required(ErrorMessage = "Please choose Reseller Name")]
        public string ResellerName { get; set; }

        [ForeignKey("ResellerAdminUser")]
        [Required(ErrorMessage = "Please choose Reseller Name")]
        public int ResellerAdminUserId { get; set; }

        public ResellerAdminUser ResellerAdminUser { get; set; }


        [Required(ErrorMessage = "Please Enter Type")]

        public string Type { get; set; } = "Postpaid/Unlimited";

        [Required(ErrorMessage = "Please Enter Inbound SMS")]

        public int InboundSMS { get; set; }
        [Required(ErrorMessage = "Please Enter Outbound SMS")]

        public int OutboundSMS { get; set; }
        [Required(ErrorMessage = "Please Enter Inbound MMS")]

        public int InboundMMS { get; set; }
        [Required(ErrorMessage = "Please Enter Outbound MMS")]

        public int OutboundMMS { get; set; }

        [Required(ErrorMessage = "Please Enter Monthly Number")]

        public int MonthlyNumber { get; set; }

        [Required(ErrorMessage = "Please Enter Users")]

        public int Users { get; set; }


        //public List<SelectListItem>? Resellers { get; set; }


    }
}
