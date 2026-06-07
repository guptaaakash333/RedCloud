using MediatR;
using RedCloud.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Templates.Queries
{
    public class GetTemplateByIdQuery : IRequest<Response<GetTemplateVM>>
    {
        public int Id { get; set; }

        public GetTemplateByIdQuery(int id)
        {
            Id = id;
        }
    }
}
