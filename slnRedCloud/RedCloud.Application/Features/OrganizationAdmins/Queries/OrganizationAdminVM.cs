using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.OrganizationAdmins.Queries
{
    public class OrganizationAdminVM
    {

        public int OrgID { get; set; }

        [Required(ErrorMessage = "Please Enter Organization Name")]
        public string OrgName { get; set; }

        [Required(ErrorMessage = "Please Enter EIN Number")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Please enter only numbers")]
        public string EIN { get; set; }


        [Required(ErrorMessage = "Please Enter Admin Name")]
        public string OrgAdminName { get; set; }

        [Required(ErrorMessage = "Please Enter Email Address")]
        [RegularExpression(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$", ErrorMessage = "Please Enter Valid Details")]
        public string OrgAdminEmail { get; set; }


        //[Required(ErrorMessage = "Please Enter Valid Details")]
        public string? OrgAdminPassword { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Please Enter Valid Details")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile number must be 10 digits and it should be in Numeric Format")]
        public string OrgAdminMobNo { get; set; }

        [Required(ErrorMessage = "Please Enter Address Line One")]
        public string AddressLineOne { get; set; }

        [Required(ErrorMessage = "Please Enter Address Line Two")]
        public string AddressLineTwo { get; set; }


        [Required(ErrorMessage = "Please Enter Zip Code")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Please enter only numbers")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Please Enter Org URL")]
        [RegularExpression(@"^(www\.)?[a-zA-Z0-9-]+\.[a-zA-Z]{2,}\.com\/?$", ErrorMessage = "Please Enter Valid Details")]
        public string OrgURL { get; set; }


        [Required(ErrorMessage = "Please Select Reseller Name")]
        public string ResellerName { get; set; } = "Test";


        [Required(ErrorMessage = "Please Select Reseller Name")]
        public int ResellerId { get; set; }

        [Required(ErrorMessage = "Please Select Reseller Name")]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "Please Select Reseller Name")]
        public int StateId { get; set; }

        [Required(ErrorMessage = "Please Select Reseller Name")]
        public int? CityId { get; set; }



    }
}
