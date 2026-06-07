
using MediatR;
using RedCloud.Application.Features.Types;
using RedCloud.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Carrierss.Queries
{
    public  class GetallCarrierListCommand:IRequest<Response<IEnumerable<CarrierVM>>>
    {
    }

    
}
