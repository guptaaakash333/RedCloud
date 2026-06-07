using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.MessagingUsers.Commands
{
    public class UpdateMessagingUserQueryHandler : IRequestHandler<UpdateMessagingUserQuery, Response<Unit>>
    {
        private readonly IAsyncRepository<UpdateMessagingUserQuery> _repository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateMessagingUserQueryHandler(IAsyncRepository<UpdateMessagingUserQuery> repository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Response<Unit>> Handle(UpdateMessagingUserQuery request, CancellationToken cancellationToken)
        {
            // var userId = _httpContextAccessor.HttpContext.Session.GetInt32("UserId");
            var parameters = new[]
            {

            new SqlParameter("@MessagingUserID", SqlDbType.Int) { Value = request.MessagingUserId },
                new SqlParameter("@MessagingUserFirstName", SqlDbType.NVarChar, 100) { Value = request.MessagingUserFirstName },
                new SqlParameter("@MessagingUserLastName", SqlDbType.NVarChar, 100) { Value = request.MessagingUserLastName },
                new SqlParameter("@MessagingUserEmail", SqlDbType.NVarChar, 100) { Value = request.MessagingUserEmail },
                new SqlParameter("@AssignedNumber", SqlDbType.NVarChar, 10) { Value = request.AssignedNumber },
                new SqlParameter("@MessagingUserType", SqlDbType.NVarChar, 50) { Value = request.MessagingUserType ?? (object)DBNull.Value },
                new SqlParameter("@IsActive", SqlDbType.Bit) { Value = request.IsActive },
                new SqlParameter("@LastModifiedBy", SqlDbType.Int) { Value = 1 }, 
                new SqlParameter("@LastModifiedDate", SqlDbType.DateTime) { Value = DateTime.Now }
            };

            var Response = await _repository.StoredProcedureCommandAsync("UpdateMessagingUsers", parameters);

            if (Response == null)
            {
                return new Response<Unit>("Rate not found");
            }

            return new Response<Unit>("Rate retrieved successfully");            
        }
    }
}
