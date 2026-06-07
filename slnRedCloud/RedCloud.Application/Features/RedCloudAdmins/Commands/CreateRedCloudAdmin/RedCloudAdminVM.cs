using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.RedCloudAdmins.Commands.CreateRedCloudAdmin
{
    public class RedCloudAdminVM
    {
        public int RedCloudAdminUserId { get; set; }

        [Required(ErrorMessage = "Please enter First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter a valId email address")]
        [EmailAddress(ErrorMessage = "Please enter a valId email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter mobile number")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile number must be 10 digits")]
        public string MobileNumber { get; set; }

        public bool IsActive { get; set; }
    }
}
