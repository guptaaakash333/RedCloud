using MediatR;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Reseller.AssignCredit.Queries
{
    public class GetRateQueryHandler : IRequestHandler<GetRateQuery, Response<IEnumerable<RateAssignCredit>>>
    {
        private readonly IAsyncRepository<RateAssignCredit> _repository;
        public GetRateQueryHandler(IAsyncRepository<RateAssignCredit> repository)
        {
            _repository = repository;
        }
        public async Task<Response<IEnumerable<RateAssignCredit>>> Handle(GetRateQuery request, CancellationToken cancellationToken)
        {
            var Res = (await _repository.StoredProcedureQueryAsync("usp_GetTypeList")).ToList();
            return new Response<IEnumerable<RateAssignCredit>>(Res, "success");
        }
    }
}
