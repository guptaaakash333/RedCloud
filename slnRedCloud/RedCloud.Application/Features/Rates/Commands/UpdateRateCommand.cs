using MediatR;
using RedCloud.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Rates.Commands
{
    public class UpdateRateCommand : IRequest<Response<int>>
    {
        public int RateId { get; set; }
        public int ResellerAdminUserId { get; set; }

        //public string ResellerName { get; set; }
        public string Type { get; set; } = "Postpaid/Unlimited";
        public int InboundSMS { get; set; }
        public int OutboundSMS { get; set; }
        public int InboundMMS { get; set; }
        public int OutboundMMS { get; set; }
        public int MonthlyNumber { get; set; }
        public int Users { get; set; }
    }

}
