using MediatR;
using RedCloud.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Reseller.AssignCredit.Commands
{
    public class AddRateCommand : IRequest<Response<int>>
    {
        public int RateAssignCreditId { get; set; }
        public int OrgID { get; set; }
        public int TypeId { get; set; }
        public string InboundSMS { get; set; }
        public string OutboundSMS { get; set; }
        public string InboundMMS { get; set; }
        public string OutboundMMS { get; set; }
        public string MonthlyNumber { get; set; }
        public string Users { get; set; }

        //public string? CreatedBy { get; set; }

        //public string? CreatedDate { get; set; }

        //public string? IsDeleted { get; set; }

        //public string? LastModifiedBy { get; set; }

        //public string? LastModifiedDate { get; set; }


    }
}
