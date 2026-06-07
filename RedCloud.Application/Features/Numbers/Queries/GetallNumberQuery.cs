using MediatR;
using RedCloud.Application.Responses;
using RedCloud.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Numbers.Queries
{
    public class GetallNumberQuery : IRequest<Response<IEnumerable<NumberlistVM>>>
    {

    }
}
