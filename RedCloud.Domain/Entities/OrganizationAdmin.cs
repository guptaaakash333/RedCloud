using RedCloud.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Domain.Entities
{
    public class OrganizationAdmin : AuditableEntity
    {
        [Key]
        public int OrgID { get; set; }
        public string OrgName { get; set; }

        public string EIN { get; set; }

        public string OrgAdminName { get; set; }

        public string OrgAdminEmail { get; set; }

        public string? OrgAdminPassword { get; set; }

        public string OrgAdminMobNo { get; set; }

        public string AddressLineOne { get; set; }

        public string AddressLineTwo { get; set; }


        public string ZipCode { get; set; }

        public string OrgURL { get; set; }

        public bool IsActive { get; set; } = true;

        public virtual List<OrganizationResellerMapping> OrganizationResellerMapping { get; set; } = new List<OrganizationResellerMapping>();

        public virtual ICollection<OrganizationUser> OrganizationUsers { get; set; } = new List<OrganizationUser>();


        public int CountryId { get; set; }

        public Country Country { get; set; }

        public int StateId { get; set; }

        public State State { get; set; }
        public int? CityId { get; set; }

        public City City { get; set; }

        //public int? NumberId { get; set; }

        //public Number? number { get; set; }

        public virtual List<Number> Numbers { get; set; } = new List<Number>();




    }
}
