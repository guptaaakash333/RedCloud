using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Numbers.Commands
{
    public class AssignNumberCommand : IRequest<Response<Unit>>
    {
        public int? NumberId { get; set; }
         public int?  ResellerAdminUserId { get; set; }
        public int? OrgID { get; set; }
       
        public int? AssignmentTypeId { get; set; }

         public int? CampaignId { get; set; }  
       
        public Status? Status { get; set; }

        public string? StartDate { get; set; }

        public string? EndDate { get; set; }


    }
}
