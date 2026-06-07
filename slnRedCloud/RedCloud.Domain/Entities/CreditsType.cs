using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Domain.Entities
{
	public class CreditsType
	{
		[Key]
		public int TypeId { get; set; }
		public string TypeName { get; set; }
	}
}
