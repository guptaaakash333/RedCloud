using MediatR;
using RedCloud.Application.Features.Countries;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Types.Queries
{
    public  class GetallTypesCommand: IRequest<Response<IEnumerable<TypesVM>>>
    {
    }
}
