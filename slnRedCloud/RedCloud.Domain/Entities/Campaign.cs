using RedCloud.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Domain.Entities
{
    public class Campaign: AuditableEntity
    {

        
            public int CampaignId { get; set; }

        public int OrganizationUserId { get; set; }

        public OrganizationUser OrganizationUser { get; set; }

        public int ResellerUserId { get; set; }

        public ResellerUser ResellerUser { get; set;}

        public string CompanyName { get; set; }

        public string UniversalEIN { get; set; }

        public int BrandId { get; set; }        

        public  string IdentityStatus { get; set; }

        

        public virtual List<Number> Numbers { get; set; } = new List<Number>();




        public string? BrandRelationship { get; set; }

        public DateOnly? BrandRegistrationDate { get; set; }

        public string CampaignIdOne { get; set; }
        public string? CampaignIdTwo { get; set; }

        public string UseCaseOne { get; set; }
        public string? UseCaseTwo { get; set; }

        public DateOnly  RegistrationDateOne { get; set; }

        public DateOnly? RegistrationDateTwo { get; set; }

        public DateOnly RenewalDateOne { get; set; }
        public DateOnly? RenewalDateTwo { get; set; }

        public string CampaignDescriptionOne { get; set; }
        public string? CampaignDescriptionTwo { get; set; }

    }



    }



