using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Reseller.AssignCredit.Queries
{
	public class OrganizationTypeVM
	{
		public int OrgID { get; set; }
		public string OrgName { get; set; }

		public string EIN { get; set; }

		public string OrgAdminName { get; set; }

		public string OrgAdminEmail { get; set; }

		public string OrgAdminPassword { get; set; }

		public string OrgAdminMobNo { get; set; }

		public string AddressLineOne { get; set; }

		public string AddressLineTwo { get; set; }
		public string ZipCode { get; set; }

		public string OrgURL { get; set; }

		public bool IsActive { get; set; } = true;

		//public List<ResellerAdminUser> ResellerAdminUsers { get; set; } = new List<ResellerAdminUser>();

		public int CountryId { get; set; }
		public int StateId { get; set; }
		public int CityId { get; set; }
		public int? CreatedBy { get; set; }
		public DateTime? CreatedDate { get; set; }
		public int? LastModifiedBy { get; set; }
		public DateTime? LastModifiedDate { get; set; }
		public bool IsDeleted { get; set; } = false;


	}
}
