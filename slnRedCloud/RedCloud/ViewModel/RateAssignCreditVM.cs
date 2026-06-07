using RedCloud.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace RedCloud.ViewModel
{
    public class RateAssignCreditVM
    {        
        public int RateAssignCreditId { get; set; }
        [Required(ErrorMessage = "Please Enter Organization Name")]
        public int OrgID { get; set; }
        [Required(ErrorMessage = "Please Enter Type Name")]
        public int TypeId { get; set; }
        [Required(ErrorMessage = "Please Enter InboundSMS")]
        public string InboundSMS { get; set; }
        [Required(ErrorMessage = "Please Enter OutboundSMS")]
        public string OutboundSMS { get; set; }
        [Required(ErrorMessage = "Please Enter InboundMMS")]
        public string InboundMMS { get; set; }
        [Required(ErrorMessage = "Please Enter OutboundMMS")]
        public string OutboundMMS { get; set; }
        [Required(ErrorMessage = "Please Enter MonthlyNumber")]
        public string MonthlyNumber { get; set;}
        [Required(ErrorMessage = "Please Enter Users")]
        public string Users { get; set;}
        public List<OrganizationAdmin>? OrganizationAdmin { get; set; }
        public List<CreditsType>? CreditsType { get; set; }

    }
}
