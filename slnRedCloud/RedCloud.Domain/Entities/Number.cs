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
    public class Number : AuditableEntity
    {
        [Key]
        public int NumberId { get; set; }
        public string? PhoneNumber { get; set; }
       // public virtual List<ResellerAdminUser> reselleradminusers { get; set; } = new List<ResellerAdminUser>();
       // public virtual List<OrganizationAdmin> organizationadmin { get; set; } = new List<OrganizationAdmin>();
        public OrganizationAdmin? OrganizationAdmin { get; set; }

        public int? OrganizationAdminID { get; set; }    
//public int OrgID { get; set; }
        public ResellerAdminUser? ResellerAdminUsers { get; set; }

        public int? ResellerAdminUserId { get; set; }
        public int? TypesId { get; set; }
        public Types? Types { get; set; }
        public int? StateId { get; set; }
        public State? State { get; set; }
        public int? AssignmentTypeId { get; set; }
        public AssignmentType? AssignmentType { get; set; }
        public int? CarrierId { get; set; }
        public Carrier? Carrier { get; set; }

        public Country? Country { get; set; }

        public int? CountryId { get; set; }
        public string? LATA { get; set; }    
        public string? RateCenter { get; set; }

        public string? StartDate { get; set; }
        public string? EndDate { get; set; }

        public int? CampaignId { get; set; }
        public Campaign? Campaign { get; set; }
        public Status? Status { get; set; }

        public bool? IsActive { get; set; }

    }
}