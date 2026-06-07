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
    public class GetAllAssignCreditQueryHandler : IRequestHandler<GetAllAssignCreditQuery, Response<IEnumerable<GetAllAssignCredit>>>
    {
        private readonly IAsyncRepository<GetAllAssignCredit> _repository;


        public GetAllAssignCreditQueryHandler(IAsyncRepository<GetAllAssignCredit> repository)
        {
            _repository = repository;
        }



        public async Task<Response<IEnumerable<GetAllAssignCredit>>> Handle(GetAllAssignCreditQuery request, CancellationToken cancellationToken)
        {
            var Res = (await _repository.StoredProcedureQueryAsync("usp_GetAllAssignCredit")).ToList();
            return new Response<IEnumerable<GetAllAssignCredit>>(Res, "success");
        }
    }
}
