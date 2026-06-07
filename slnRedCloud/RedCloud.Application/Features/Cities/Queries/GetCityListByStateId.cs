using MediatR;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Cities.Queries
{
    public class GetCityListByStateId : IRequest<Response<IEnumerable<CityListVM>>>
    {
        public int StateId { get; set; }
    }
}
