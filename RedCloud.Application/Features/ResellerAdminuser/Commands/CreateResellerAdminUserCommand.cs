using MediatR;
using RedCloud.Application.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.ResellerAdminuser.Commands
{
    public class CreateResellerAdminUserCommand:IRequest<Response<int>>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Reseller name is required")]
        public string ResellerName { get; set; }

        [Required(ErrorMessage = "EIN is required")]
        [RegularExpression(@"^\d{2}-\d{7}$", ErrorMessage = "Please enter a valId EIN (XX-XXXXXXX)")]
        public string EIN { get; set; }

        [Required(ErrorMessage = "Address Line 1 is required")]
        public string AddressLine1 { get; set; }

        [Required(ErrorMessage = "Address Line 2 is required")]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "City is required")]
        public int CityId { get; set; }//c

        [Required(ErrorMessage = "State is required")]
        public int StateId { get; set; }//c

        [Required(ErrorMessage = "Zip Code is required")]
        //  [RegularExpression(@"^\d{5}(?:[-\s]\d{4})?$", ErrorMessage = "Please enter a valId Zip Code")]
        public int ZipCode { get; set; }

        [Required(ErrorMessage = "Company URL is required")]
        //  [Url(ErrorMessage = "Please enter a valId URL")]
        public string CompanyURL { get; set; }

        [Required(ErrorMessage = "Company Support Email is required")]
        //  [EmailAddress(ErrorMessage = "Please enter a valId email address")]
        public string CompanySupportEmail { get; set; }

        //      [Required(ErrorMessage = "Red Cloud Admin is required")]
        public string? RedCloudAdmin { get; set; }

        public string? Password { get; set; }

        public bool IsActive { get; set; }

        public int CountryId { get; set; }//c

    }
}
