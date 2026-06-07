using MediatR;
using RedCloud.Application.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Campaigns.Commands
{
    public class CreateCampaignCommand : IRequest<Response<int>>
    {
        public int OrganizationUserId { get; set; }

        public int ResellerUserId { get; set; }

        public string CompanyName { get; set; }

        public string UniversalEIN { get; set; }

        public int BrandId { get; set; }

        public string IdentityStatus { get; set; }

        public string? BrandRelationship { get; set; }

        public DateOnly? BrandRegistrationDate { get; set; }

        public string CampaignIdOne { get; set; }
        public string UseCaseOne { get; set; }
        public DateOnly RegistrationDateOne { get; set; }
        public DateOnly RenewalDateOne { get; set; }

        public string CampaignDescriptionOne { get; set; }


        public string? CampaignIdTwo { get; set; }

        public string? UseCaseTwo { get; set; }

        public DateOnly? RegistrationDateTwo { get; set; }

        public DateOnly? RenewalDateTwo { get; set; }

        public string? CampaignDescriptionTwo { get; set; }

        public int? userID { get; set; }
    }
}
