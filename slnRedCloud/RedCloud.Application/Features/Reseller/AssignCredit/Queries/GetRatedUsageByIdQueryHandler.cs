using MediatR;
using Microsoft.Data.SqlClient;
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
    public class GetRatedUsageByIdQueryHandler : IRequestHandler<GetRatedUsageByIdQuery, Response<GetRatedUsage>>
    {
        private readonly IAsyncRepository<GetRatedUsage> _asyncRepository;
        private readonly IAsyncRepository<getRatedUsageList> _asyncRepositoryb;

        public GetRatedUsageByIdQueryHandler(IAsyncRepository<GetRatedUsage> asyncRepository, IAsyncRepository<getRatedUsageList> asyncRepositoryb)
        {
            _asyncRepository = asyncRepository;
            _asyncRepositoryb = asyncRepositoryb;

        }


        public async Task<Response<GetRatedUsage>> Handle(GetRatedUsageByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var parameters = new[]
                {
                    new SqlParameter("@GetRateAssignCreditId", request.GetRateAssignCreditId),
                };

                //var assignCredit = await _asyncRepository.GetByIdAsyncInculde(request.Id);
                var assignCreditUse = (await _asyncRepository.StoredProcedureQueryAsync("usp_GetRatedUsage", parameters)).FirstOrDefault();

                var assignCreditUseList = (await _asyncRepositoryb.StoredProcedureQueryAsync("usp_GetRatedUsageList", parameters)).ToList();

                assignCreditUse.getRatedUsageLists = assignCreditUseList;

                if (assignCreditUse == null)
                {
                    return new Response<GetRatedUsage>("Detail Not found");
                }

                return new Response<GetRatedUsage>(assignCreditUse, "assignCredit Data retrieved successfully");
            }
            catch (Exception ex)
            {
                return new Response<GetRatedUsage>($"Error retrieving rate by Id: {ex.Message}");
            }
        }
    }
}
