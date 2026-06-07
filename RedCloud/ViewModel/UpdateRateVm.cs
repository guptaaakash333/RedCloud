using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RedCloud.ViewModel
{
    public class UpdateRateVm
    {
        [Key]

        public int RateId { get; set; }

        [ForeignKey("ResellerAdminUser")]
        public int ResellerAdminUserId { get; set; }

        [Display(Name = "Reseller Name")]
        

        public string ResellerName { get; set; }

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

        

        
    }
}
