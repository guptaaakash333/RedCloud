using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Campaign
{
    public  class CampaignVM
    {
        public int CampaignId { get; set; }

        //public int OrgID { get; set; }

        //public OrganizationAdmin organizationAdmin { get; set; }

        //public int ResellerAdminUserId { get; set; }

        //public ResellerAdminUser resellerAdminUser { get; set; }

        //public string CompanyName { get; set; }

        //public string UniversalEIN { get; set; }

        //public int BrandId { get; set; }

        //public bool IsActive { get; set; } = true;

        public bool IsDeleted { get; set; } = false;

        public virtual List<Number> Numbers { get; set; } = new List<Number>();
    }
}
