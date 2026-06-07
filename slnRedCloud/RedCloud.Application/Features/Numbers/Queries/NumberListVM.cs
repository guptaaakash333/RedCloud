using RedCloud.Domain.Entities;

namespace RedCloud.ViewModel
{
  
        public class NumberlistVM
        {
            //[Required(ErrorMessage = "Phone number is required")]
            //[Phone(ErrorMessage = "Invalid phone number format")]

            public int NumberId { get; set; }
            public string PhoneNumber { get; set; }
            // [Required(ErrorMessage = "CarrierName is required")]
            public string CarrierName { get; set; }
            // [Required(ErrorMessage = "OrgName is required")]
            public string OrgName { get; set; }
            //[Required(ErrorMessage = "Status is required")]
            public bool IsActive { get; set; }
            //[Required(ErrorMessage = "Status is required")]
            public Status Status { get; set; }
        }
    
}
