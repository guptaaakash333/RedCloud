using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Domain.Entities
{
    public class GetAllAssignNumber
    {
        
        public int? NumberId { get; set; }

        public string? AllocatedDate { get; set; }

        public string? Number { get; set; }
        public string? AssignedType { get; set; }
        public string? AssignedUser { get; set; }
        public bool StatusType { get; set; }


    }
}
