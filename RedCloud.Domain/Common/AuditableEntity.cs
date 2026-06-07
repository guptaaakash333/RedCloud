using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Domain.Common
{
    public class AuditableEntity
    {
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }= DateTime.Now;
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }=DateTime.Now;
        public bool IsDeleted { get; set; } = false;

    }
}
