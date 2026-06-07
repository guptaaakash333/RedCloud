using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.OrganizationAdmins.Queries
{
    public class OrganizationAdminDetailsVM
    {
        public int OrgID { get; set; }
        public string OrgName { get; set; }

        public string OrgAdminName { get; set; } // Assuming you want the name of the organization admin

        public string OrgAdminEmail { get; set; }

        public string OrgAdminMobNo { get; set; }

        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }

        public string CountryName { get; set; } // Assuming you want the name of the country
        public string StateName { get; set; } // Assuming you want the name of the state
        public string CityName { get; set; } // Assuming you want the name of the city

        public string ZipCode { get; set; }

        public string EIN { get; set; }

        public string CompanyURL { get; set; }

        public bool IsActive { get; set; } 
        public int ResellerId { get; set; }

        public string OrgAdminPassword { get; set; }


    }
}
