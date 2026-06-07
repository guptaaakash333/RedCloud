using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Domain.Entities
{
    public class TotalReport
    {
        public int TotalUsers { get; set; }
        public int TotalNumbers { get; set; }
        public int TotalInboundSMS { get; set; }
        public int TotalOutboundSMS { get; set; }
        public int TotalInboundMMS { get; set; }
        public int TotalOutboundMMS { get; set; }
    }
}
