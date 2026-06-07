using MediatR;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.OrganizationAdmins.Commands
{
    public class CreateOrganizationAdminCommand : IRequest<Response<int>>
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

        //public string Country { get; set; }

        //public string City {  get; set; }

        //public string State {  get; set; }

        //public string Country { get; set; }

        public string ZipCode { get; set; }

        public string OrgURL { get; set; }

        public bool IsActive { get; set; } 

        public int ResellerId { get; set; }



        public int CountryId { get; set; }



        public int StateId { get; set; }


        public int? CityId { get; set; }

        //public List<ResellerAdminUser> resellerAdminUsers { get; set; }



    }
}
