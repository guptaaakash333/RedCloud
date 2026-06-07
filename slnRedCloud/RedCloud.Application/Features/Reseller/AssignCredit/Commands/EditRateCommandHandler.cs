using MediatR;
using Microsoft.Data.SqlClient;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.Account.Commands;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Reseller.AssignCredit.Commands
{
    public class EditRateCommandHandler : IRequestHandler<EditRateCommand, Response<Unit>>
    {
        private readonly IAsyncRepository<RateAssignCredit> _repository;
        public EditRateCommandHandler(IAsyncRepository<RateAssignCredit> repository) 
        { 
            _repository = repository;
        }

        public async Task<Response<Unit>> Handle(EditRateCommand request, CancellationToken cancellationToken)
        {
            var parameters = new[]
           {
                new SqlParameter("@RateAssignCreditId", request.RateAssignCreditId),
                new SqlParameter("@OrgID", request.OrgID),
                new SqlParameter("@TypeId", request.TypeId),
                new SqlParameter("@InboundSMS", request.InboundSMS),
                new SqlParameter("@OutboundSMS", request.OutboundSMS),
                new SqlParameter("@InboundMMS", request.InboundMMS),
                new SqlParameter("@OutboundMMS", request.OutboundMMS),
                new SqlParameter("@MonthlyNumber", request.MonthlyNumber),
                new SqlParameter("@Users", request.Users)
            };

            try
            {
                var Res = await _repository.StoredProcedureCommandAsync("usp_ResellerCreditUpdateRate", parameters);

                if (Res == null)
                {
                    return new Response<Unit>("Rate not found");
                }

                return new Response<Unit>("Rate retrieved successfully");
            }
            catch (Exception ex)
            {
                return new Response<Unit>($"Error retrieving rate by Id: {ex.Message}");
            }
        }
    }
}
