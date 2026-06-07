using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Models.Cache
{
    public class CacheConfiguration
    {
        public int AbsoluteExpirationInHours { get; set; }
        public int SlIdingExpirationInMinutes { get; set; }

    }
}
