using RedCloud.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Domain.Entities
{
    public class ResellerAdminUser : AuditableEntity
    {

        [Key]
        public int ResellerAdminUserId { get; set; }

        public string ResellerName { get; set; }
        public string EIN { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public string ZipCode { get; set; }

        public string CompanyURL { get; set; }
        public string CompanySupportEmail { get; set; }

        public string? RedCloudAdmin { get; set; }

        public string? Password { get; set; }

        public bool IsActive { get; set; } = true;


        //   public int? OrganizationAdminId { get; set; }


        //public virtual OrganizationAdmin? OrganizationAdmins { get; set; }

        public virtual ICollection<RedCloudAdmin>? RedCloudAdmins { get; set; } = new List<RedCloudAdmin>();


            public virtual List<OrganizationResellerMapping>? OrganizationResellerMapping { get; set; } = new List<OrganizationResellerMapping>();


        public virtual List<ResellerUser>? ResellerUser { get; set; } = new List<ResellerUser>();

        public int CountryId { get; set; }

        public Country? Country { get; set; }

        public int StateId { get; set; }
        public State? State { get; set; }

        public int CityId { get; set; }

        public City? City { get; set; }
        //public int? NumberId { get; set; }
        //public Number? Number { get; set; }

        public virtual ICollection<Number>? Numbers { get; set; } = new List<Number>();

        //public int? ResellerUserId { get; set; }

        //public ResellerUser? ResellerUser { get; set; }

    }






}

