using RedCloud.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace RedCloud.ViewModel
{
    public class CarrierVM
    {

        [Key]
        public int CarrierId { get; set; }
        public string CarrierName { get; set; }
        public virtual ICollection<Number> Numbers { get; set; } = new List<Number>();
    }
}
