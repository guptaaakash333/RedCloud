    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Domain.Entities
{
    public class Types
    {
        [Key]
        public int TypesId { get; set; }
        public string TypesName { get; set; }
        public virtual ICollection<Number> Numbers { get; set; } = new List<Number>();
    }
}
