using MediatR;
using RedCloud.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Countries
{
    public class GetCountryList : IRequest<Response<IEnumerable<CountryListVM>>>
    {
    }
}
