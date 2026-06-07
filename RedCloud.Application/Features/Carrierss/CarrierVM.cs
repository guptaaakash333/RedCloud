using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Carrierss
{
    public  class CarrierVM
    {

        [Key]
        public int CarrierId { get; set; }
        public string CarrierName { get; set; }
        public virtual ICollection<Number> Numbers { get; set; } = new List<Number>();
    }
}
