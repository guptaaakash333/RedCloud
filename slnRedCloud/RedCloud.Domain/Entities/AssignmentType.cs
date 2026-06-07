using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Domain.Entities
{
    public class AssignmentType
    {
        [Key]
        public int AssignmentTypeId { get; set; }
        public string AssignmentTypeName { get; set; }
       //public virtual ICollection<Number> Numbers { get; set; } = new List<Number>();
    }
}
