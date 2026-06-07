using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Cities.Queries
{
    public class CityListVM
    {
        public int StateId { get; set; }
        public int CityId { get; set; }

        public string Name { get; set; }
    }
}
