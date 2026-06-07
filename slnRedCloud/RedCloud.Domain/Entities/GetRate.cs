using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Domain.Entities
{
    public class GetRate
    {
        //SELECT r.RateId as GetRateId, ru.ResellerName as GetResellerName, r.MonthlyNumber as GetMonthlyNumber, r.Users as GetUsers
        [Key]
        public int GetRateId { get; set; }
        public string GetResellerName { get; set; }
        public int GetMonthlyNumber { get; set; }
        public int GetUsers { get; set; }

        

    }
}
