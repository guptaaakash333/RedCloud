using MediatR;
using RedCloud.Application.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.ResellerUsers.Command
{
    public class UpdateResellerUserCommand:IRequest<Response<Unit>>
    {

        public int ResellerUserId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        // [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public int? ResellerAdminUserId { get; set; }

      //  [StringLength(100, ErrorMessage = "Reseller Admin User Name cannot be longer than 100 characters.")]
      //  public string? ResellerAdminUserName { get; set; } // Assuming you want to display the name or some detail of ResellerAdminUser

        public string? Passaword { get; set; }
        public bool IsActive { get; set; } 

    }
}
