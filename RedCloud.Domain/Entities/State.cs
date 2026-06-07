using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Domain.Entities
{
    public class State
    {
        [Key]
        public int StateId { get; set; }
        public string Name { get; set; }

        public int CountryId { get; set; }

        public virtual Country Countries { get; set; }

        public virtual ICollection<City> Cities { get; set; } = new List<City>();
    }
}
