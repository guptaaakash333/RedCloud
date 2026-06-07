using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Domain.Entities
{
    public class City
    {


        [Key]
        public int CityId { get; set; }
        public string Name { get; set; }

        public int StateId { get; set; }
        public virtual State State { get; set; }


        //  public virtual ICollection<ResellerAdmin> ResellerAdmins { get; set; } = new List<ResellerAdmin>();
    }
}
