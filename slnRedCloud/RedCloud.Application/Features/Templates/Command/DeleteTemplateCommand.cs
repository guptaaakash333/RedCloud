using MediatR;
using RedCloud.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Templates.Command
{
    public class DeleteTemplateCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
