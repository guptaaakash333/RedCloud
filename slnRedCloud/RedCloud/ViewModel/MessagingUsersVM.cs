using System.ComponentModel.DataAnnotations;

namespace RedCloud.ViewModel
{
    public class MessagingUsersVM
    {
        public int MessagingUserId { get; set; }


        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")]
        public string MessagingUserFirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        public string MessagingUserLastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Email")]
        public string MessagingUserEmail { get; set; }

        [Required(ErrorMessage = "Assigned Number is required")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Assigned Number must be exactly 10 digits")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Assigned Number must be numeric")]
        [Display(Name = "Add Number")]
        public string AssignedNumber { get; set; }

        [Required(ErrorMessage = "User Type is required")]
        [Display(Name = "User Type")]
        public string MessagingUserType { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }



    }
}
