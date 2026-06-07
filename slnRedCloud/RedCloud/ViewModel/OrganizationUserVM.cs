using System.ComponentModel.DataAnnotations;

namespace RedCloud.ViewModel
{
    public class OrganizationUserVM
    {
        public int OrganizationUserId { get; set; }

        [Required(ErrorMessage = "First Name is Required.")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string OrganizationUserFirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required.")]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string OrganizationUserLastName { get; set; }

        [Required(ErrorMessage = "Email is Required.")]

        public string OrganizationUserEmail { get; set; }

        public string? OrganizationUserPassword { get; set; }

        public bool IsActive { get; set; } 

        public int? OrganizationAdminId { get; set; }
    }
}
