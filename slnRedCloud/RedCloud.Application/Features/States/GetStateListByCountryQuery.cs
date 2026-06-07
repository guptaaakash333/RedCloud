using MediatR;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.States
{
    public class GetStateListByCountryQuery : IRequest<Response<IEnumerable<State>>>
    {
        public int CountryId { get; set; }
    }
}
