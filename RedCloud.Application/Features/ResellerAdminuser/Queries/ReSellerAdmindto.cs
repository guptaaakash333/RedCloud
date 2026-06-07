using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.ResellerAdminuser.Queries
{
    public class ReSellerAdmindto
    {
        public int ResellerAdminUserId { get; set; }
        public string ResellerName { get; set; }
        public string EIN { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string ZipCode { get; set; }
        public string CompanyURL { get; set; }
        public string CompanySupportEmail { get; set; }
        public string RedCloudAdmin { get; set; }
        public bool IsActive { get; set; }
        public int OrganizationAdminId { get; set; }
        public string OrganizationAdminName { get; set; } // Assuming you want the name of the organization admin
        public string CountryName { get; set; } // Assuming you want the name of the country
        public string StateName { get; set; } // Assuming you want the name of the state
        public string CityName { get; set; } // Assuming you want the name of the city
        public bool IsDeleted { get; set; }
        public string? Password { get; set; }

        
    }
}
