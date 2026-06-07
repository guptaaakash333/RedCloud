using RedCloud.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Domain.Entities
{
    public class Template : AuditableEntity
    {
        public int TemplateId { get; set; }

        public string TemplateName { get; set; }

        public string MessageType { get; set; }

        public string TemplatePersonalization { get; set; }

        public string MessageBody { get; set; }

        public string TemplateURL { get; set; }
    }
}
