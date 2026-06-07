using MediatR;
using Microsoft.Data.SqlClient;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.Account.Queries;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Reseller.AssignCredit.Queries
{
    public class GetRateByIdQueryHandler : IRequestHandler<GetRateByIdQuery, Response<RateAssignCredit>>
    {
        private readonly IAsyncRepository<RateAssignCredit> _repository;
        public GetRateByIdQueryHandler(IAsyncRepository<RateAssignCredit> repository)
        {
            _repository = repository;
        }
        public async Task<Response<RateAssignCredit>> Handle(GetRateByIdQuery request, CancellationToken cancellationToken)
        {
            //var Res2 = await _repository.StoredProcedureQueryAsync("usp_GetOrganizationType");
            var parameters = new[]
            {
                new SqlParameter("@RateAssignCreditId", request.RateAssignCreditId)
            };

            try
            {
                var Res = (await _repository.StoredProcedureQueryAsync("usp_GetCreditRateById", parameters)).FirstOrDefault();

                //var Res = await _repository.StoredProcedureQueryAsync("usp_GetUserByEmail", parameters);

                if (Res == null)
                {
                    return new Response<RateAssignCredit>("Rate not found");
                }

                return new Response<RateAssignCredit>(Res, "Rate retrieved successfully");
            }
            catch (Exception ex)
            {
                return new Response<RateAssignCredit>($"Error retrieving rate by Id: {ex.Message}");
            }
        }
    }
}
