using RedCloud.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Domain.Entities
{
    public  class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<State> States { get; set; } = new List<State>();
    }
}
