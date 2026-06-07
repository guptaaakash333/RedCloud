using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Domain.Entities
{
    public class Message
    {
        public Guid MessageId { get; set; }
        public string Code { get; set; }
        public string MessageContent { get; set; }
        public string Language { get; set; }
        public MessageType Type { get; set; }

        public enum MessageType
        {
            Information,
            Error,
            Warning
        }

    }
}
