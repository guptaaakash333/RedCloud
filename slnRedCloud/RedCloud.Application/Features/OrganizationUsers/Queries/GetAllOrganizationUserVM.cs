using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.OrganizationUsers.Queries
{
    public class GetAllOrganizationUserVM
    {
        public int OrganizationUserId { get; set; }

        //[Required(ErrorMessage = "First name is required.")]
        //[StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string OrganizationUserFirstName { get; set; }

        //[Required(ErrorMessage = "Last name is required.")]
        //[StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string OrganizationUserLastName { get; set; }

       // [Required(ErrorMessage = "Email is required.")]

        public string OrganizationUserEmail { get; set; }

        public string OrganizationUserPassword { get; set; }

        public bool IsActive { get; set; } 

        public int OrganizationAdminId { get; set; }

    }
}
