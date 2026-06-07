using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Campaigns.Queries
{
    public class CampaignVM
    {

        //public int CampaignId { get; set; }

        //[Required(ErrorMessage = "Company name is required")]
        //public string CompanyName { get; set; }

        //[Required(ErrorMessage = "Universal EIN is required")]
        //// [RegularExpression(@"^\d{9}$", ErrorMessage = "Universal EIN must be a 9-digit number")]
        //public int UniversalEIN { get; set; }

        //[Required(ErrorMessage = "Brand ID is required")]
        //public int BrandId { get; set; }

        //public bool IsActive { get; set; } = true;

        public int CampaignId { get; set; }

        [Required(ErrorMessage = "Please Select Organization Name")]
        public int? OrganizationUserId { get; set; }

        [Required(ErrorMessage = "Please Select Reseller Name")]
        public int? ResellerUserId { get; set; }


        [Required(ErrorMessage = "Please Enter Company Name")]
        [StringLength(100, ErrorMessage = "Company Name cannot exceed 100 characters.")]
        public string? CompanyName { get; set; }


        [Required(ErrorMessage = "Please Enter Universal EIN")]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Universal EIN must be a 6-digit number.")]
        public string? UniversalEIN { get; set; }


        [Required(ErrorMessage = "Please Enter Brand ID")]
        public int? BrandId { get; set; }


        [Required(ErrorMessage = "Please select Identity Status ")]
        public string? IdentityStatus { get; set; }


        [Required(ErrorMessage = "Please Enter Brand Relationship")]
        [StringLength(100, ErrorMessage = "Brand Relationship cannot exceed 100 characters.")]
        public string? BrandRelationship { get; set; }


        [Required(ErrorMessage = "Please Enter Brand Registration Date ")]
        public DateOnly? BrandRegistrationDate { get; set; }


        [Required(ErrorMessage = "Please Enter Campaign ID ")]
        [StringLength(50, ErrorMessage = "Campaign ID One cannot exceed 50 characters.")]
        public string? CampaignIdOne { get; set; }


        [StringLength(50, ErrorMessage = "Campaign ID Two cannot exceed 50 characters.")]
        public string? CampaignIdTwo { get; set; }

        [Required(ErrorMessage = "Please Enter Use Case")]
        [StringLength(200, ErrorMessage = "Use Case One cannot exceed 200 characters.")]
        public string? UseCaseOne { get; set; }


        [StringLength(200, ErrorMessage = "Use Case Two cannot exceed 200 characters.")]
        public string? UseCaseTwo { get; set; }


        [Required(ErrorMessage = "Please select Registration Date")]
        [DataType(DataType.Date)]
        public DateOnly? RegistrationDateOne { get; set; }


        [DataType(DataType.Date)]
        public DateOnly? RegistrationDateTwo { get; set; }


        [Required(ErrorMessage = "Please select Renewal Date")]
        [DataType(DataType.Date)]
        public DateOnly? RenewalDateOne { get; set; }


        [DataType(DataType.Date)]
        public DateOnly? RenewalDateTwo { get; set; }


        [Required]
        [StringLength(500, ErrorMessage = "Campaign Description One cannot exceed 500 characters.")]
        public string? CampaignDescriptionOne { get; set; }


        [StringLength(500, ErrorMessage = "Campaign Description Two cannot exceed 500 characters.")]
        public string? CampaignDescriptionTwo { get; set; }

        public int? userID { get; set; }

        public virtual List<Number>? Numbers { get; set; } = new List<Number>();

        public bool? IsDeleted { get; set; } = false;



    }
}
