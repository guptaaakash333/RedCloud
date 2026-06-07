using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Domain.Entities
{
    public class GetAllAssignCredit
    {
        [Key]
        public int RateAssignCreditId { get; set; }
        public string GetAllAssignCreditName { get; set; }
        public string GetAllAssignCreditTypeName { get; set; }
    }
}
