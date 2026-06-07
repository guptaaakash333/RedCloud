using AutoMapper;
using MediatR;
using Microsoft.Data.SqlClient;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.Campaigns.Queries;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Reseller.AssignCredit.Queries
{
    public class GetAssignCreditByIdQueryHandler : IRequestHandler<GetAssignCreditByIdQuery, Response<AssignCreditDetailsVM>>
    {
        private readonly IAsyncRepository<AssignCreditDetailsVM> _asyncRepository;
        //private readonly IMapper _mapper;

        public GetAssignCreditByIdQueryHandler(IAsyncRepository<AssignCreditDetailsVM> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            //_mapper = mapper;
        }


        public async Task<Response<AssignCreditDetailsVM>> Handle(GetAssignCreditByIdQuery request, CancellationToken cancellationToken)
        {

            try
            {
                var parameters = new[]
                {
                    new SqlParameter("@GetRateAssignCreditId", request.GetRateAssignCreditId),
                };

                //var assignCredit = await _asyncRepository.GetByIdAsyncInculde(request.Id);
                var assignCredit = (await _asyncRepository.StoredProcedureQueryAsync("GetAssignCreditById", parameters)).FirstOrDefault();

                if (assignCredit == null)
                {
                    return new Response<AssignCreditDetailsVM>("Detail Not found");
                }

                return new Response<AssignCreditDetailsVM>(assignCredit,"assignCredit Data retrieved successfully");
            }
            catch (Exception ex)
            {
                return new Response<AssignCreditDetailsVM>($"Error retrieving rate by Id: {ex.Message}");
            }
        }
    }
}
