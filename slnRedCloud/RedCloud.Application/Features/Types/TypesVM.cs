using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Types
{
    public class TypesVM
    {
        [Key]
        public int TypesId { get; set; }
        public string TypesName { get; set; }
        public virtual ICollection<Number> Numbers { get; set; } = new List<Number>();
    }
}
