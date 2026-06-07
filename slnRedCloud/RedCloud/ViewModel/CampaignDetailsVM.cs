namespace RedCloud.ViewModel
{
    public class CampaignDetailsVM
    {
        public int CampaignId { get; set; }

        public string? OrganizationUserName { get; set; }

        public string? ResellerUserName { get; set; }

        public string? CompanyName { get; set; }

        public string? UniversalEIN { get; set; }

        public int? BrandId { get; set; }

        public string? IdentityStatus { get; set; }

        public string? BrandRelationship { get; set; }

        public DateOnly? BrandRegistrationDate { get; set; }

        public string? CampaignIdOne { get; set; }
        public string? UseCaseOne { get; set; }
        public DateOnly? RegistrationDateOne { get; set; }
        public DateOnly? RenewalDateOne { get; set; }

        public string? CampaignDescriptionOne { get; set; }


        public string? CampaignIdTwo { get; set; }

        public string? UseCaseTwo { get; set; }

        public DateOnly? RegistrationDateTwo { get; set; }

        public DateOnly? RenewalDateTwo { get; set; }

        public string? CampaignDescriptionTwo { get; set; }
    }
}
