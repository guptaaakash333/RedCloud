using MediatR;
using Microsoft.Data.SqlClient;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.OrganizationAdmins.Commands;
using RedCloud.Application.Features.ResellerAdminuser.Commands;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Reseller.AssignCredit.Commands
{
    public class AddRateCommandHandler : IRequestHandler<AddRateCommand, Response<int>>
    {
        private readonly IAsyncRepository<RateAssignCredit> _repository;
        public AddRateCommandHandler(IAsyncRepository<RateAssignCredit> repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(AddRateCommand request, CancellationToken cancellationToken)
        {
            var parameters = new[]
           {
                //new SqlParameter("@RateAssignCreditId", request.RateAssignCreditId),
                new SqlParameter("@OrgID", request.OrgID),
                new SqlParameter("@TypeId", request.TypeId),
                new SqlParameter("@InboundSMS", request.InboundSMS),
                new SqlParameter("@OutboundSMS", request.OutboundSMS),
                new SqlParameter("@InboundMMS", request.InboundMMS),
                new SqlParameter("@OutboundMMS", request.OutboundMMS),
                new SqlParameter("@MonthlyNumber", request.MonthlyNumber),
                new SqlParameter("@Users", request.Users)//,
                //new SqlParameter("@CreatedBy", request.CreatedBy),
                //new SqlParameter("@CreatedDate", request.CreatedDate),
                //new SqlParameter("@IsDeleted", request.IsDeleted),
                //new SqlParameter("@LastModifiedBy", request.LastModifiedBy),
                //new SqlParameter("@LastModifiedDate",request.LastModifiedDate)
            };

            try
            {
                var Res = await _repository.StoredProcedureCommandAsync("usp_AddRate", parameters);
                //var Res = await _repository.StoredProcedureQueryAsync("usp_GetUserByEmail", parameters);

                if (Res == null)
                {
                    return new Response<int>("Rate not found");
                }

                return new Response<int>("Rate retrieved successfully");
            }
            catch (Exception ex)
            {
                return new Response<int>($"Error retrieving rate by Id: {ex.Message}");
            }

            //var response = new Response<int>(result.ResellerAdminUserId, "Inserted successfully ");
            //return response;
        }
    }
}
