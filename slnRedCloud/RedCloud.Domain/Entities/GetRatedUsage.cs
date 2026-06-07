using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Domain.Entities
{
    public class GetRatedUsage
    {
        
        public string TypeName { get; set; }  
        public string Users { get; set; }
        public int MessageOutbound { get; set; }
        public int MessageInbound { get; set; }

        public List<getRatedUsageList>? getRatedUsageLists { get;set;}

    }

    public class getRatedUsageList
    {
        
        public string? UsageElements { get; set; }
        [Key]
        public string Rate { get; set; }
    }
}
