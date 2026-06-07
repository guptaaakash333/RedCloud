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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RedCloud.Application.Features.Account.Queries
{
    public class UserExistByEmailQueryHandler : IRequestHandler<UserExistByEmailQuery, Response<User>>
    {
        private readonly IAsyncRepository<User> _repository;

        public UserExistByEmailQueryHandler(IAsyncRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<Response<User>> Handle(UserExistByEmailQuery request, CancellationToken cancellationToken)
        {
            var parameters = new[]
            {
                new SqlParameter("@Email", request.Email)
            };

            try
            {
                var Res = (await _repository.StoredProcedureQueryAsync("usp_GetUserByEmail", parameters)).FirstOrDefault();
                //var Res = await _repository.StoredProcedureQueryAsync("usp_GetUserByEmail", parameters);

                if (Res == null)
                {
                    return new Response<User>("Rate not found");
                }

                return new Response<User>(Res, "Rate retrieved successfully");
            }
            catch (Exception ex)
            {
                return new Response<User>($"Error retrieving rate by Id: {ex.Message}");
            }
        }
    }
}
