using RedCloud.Domain.Entities;

namespace RedCloud.ViewModel
{
  
        public class NumberlistVM
        {
        public int NumberId { get; set; }
        //[Required(ErrorMessage = "Phone number is required")]
        //[Phone(ErrorMessage = "Invalid phone number format")]
        public string PhoneNumber { get; set; }
        // [Required(ErrorMessage = "CarrierName is required")]

        public string CarrierName { get; set; }
        public int? CarrierId { get; set; }

        public int? OrgID { get; set; }

        public string OrgName { get; set; }
        //[Required(ErrorMessage = "Status is required")]
        public bool IsActive { get; set; }
            //[Required(ErrorMessage = "Status is required")]
            public Status Status { get; set; }
        }
    
}
