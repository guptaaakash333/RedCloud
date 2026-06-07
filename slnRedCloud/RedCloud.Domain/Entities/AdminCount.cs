using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Domain.Entities
{
    public class AdminCount
    {
        public int TotalResellers { get; set; }
        public int TotalOrganizations { get; set; }
        public int TotalNumbers { get; set; }
        public int TotalTollfreeNumbers { get; set; }
    }
}
