using MediatR;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Rates.Queries
{
    public class SoftDeleteRateQuery : IRequest<Response<Rate>>
    {
        public int Id { get; set; }
    }

}
