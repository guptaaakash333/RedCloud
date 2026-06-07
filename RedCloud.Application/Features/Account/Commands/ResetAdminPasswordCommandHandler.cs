using MediatR;
using Microsoft.Data.SqlClient;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.OrganizationAdmins.Commands;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Account.Commands
{
    public class ResetAdminPasswordCommandHandler : IRequestHandler<ResetAdminPasswordCommand, Response<Unit>>
    {
        private readonly IAsyncRepository<User> _repository;
        public ResetAdminPasswordCommandHandler(IAsyncRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<Response<Unit>> Handle(ResetAdminPasswordCommand request, CancellationToken cancellationToken)
        {
            var parameters = new[]
           {
                new SqlParameter("@UserId", request.UserId),
                new SqlParameter("@Email", request.Password)
            };

            try
            {
                var Res = await _repository.StoredProcedureCommandAsync("usp_ResetPassword", parameters);
                //var Res = await _repository.StoredProcedureQueryAsync("usp_GetUserByEmail", parameters);

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

            //var model = await _repository.GetByIdAsync(request.OrgID);
            //request.OrgAdminPassword = model.OrgAdminPassword;
            //_mapper.Map(request, model, typeof(UpdateOrganizationAdminCommand), typeof(OrganizationAdmin));

            //model.LastModifiedBy = 1;
            //model.LastModifiedDate = DateTime.Now;
            //await _repository.UpdateAsync(model);
            //var response = new Response<Unit>("Inserted successfully");
            //return response;
        }
    }
}
