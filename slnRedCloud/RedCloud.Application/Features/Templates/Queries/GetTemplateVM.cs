using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Templates.Queries
{
    public class GetTemplateVM
    {
        public int TemplateId { get; set; }

        public string TemplateName { get; set; }

        public string MessageType { get; set; }

        public string TemplatePersonalization { get; set; }

        public string MessageBody { get; set; }

        public string TemplateURL { get; set; }

        public int SessionId { get; set; }
    }
}
