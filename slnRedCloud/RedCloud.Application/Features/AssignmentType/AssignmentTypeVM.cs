using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.AssignmentType
{
    public  class AssignmentTypeVM
    {
        [Key]
        public int AssignmentTypeId { get; set; }
        public string AssignmentTypeName { get; set; }

    }
}
