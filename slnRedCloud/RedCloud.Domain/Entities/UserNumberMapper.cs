using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Domain.Entities
{
        public class UsersNumberMapper
        {
            [Key]
            public int UsersNumberMapperId { get; set; }

            public int MessagingUserId { get; set; }

            public virtual MessagingUser MessagingUser { get; set; }

            public int NumberId { get; set; }

            public virtual Number Number { get; set; }
        }

}
