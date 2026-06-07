using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.Rates.Commands;
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
    public class AddMessagingUserQueryHandler : IRequestHandler<AddMessagingUserQuery, Response<int>>
    {
        private readonly IAsyncRepository<MessagingUser> _repository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AddMessagingUserQueryHandler(IAsyncRepository<MessagingUser> repository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Response<int>> Handle(AddMessagingUserQuery request, CancellationToken cancellationToken)
        {
            // var userId = _httpContextAccessor.HttpContext.Session.GetInt32("UserId");
            var parameters = new[]
            {

            new SqlParameter("@MessagingUserFirstName", SqlDbType.NVarChar, 100) { Value = request.MessagingUserFirstName },
                new SqlParameter("@MessagingUserLastName", SqlDbType.NVarChar, 100) { Value = request.MessagingUserLastName },
                new SqlParameter("@MessagingUserEmail", SqlDbType.NVarChar, 100) { Value = request.MessagingUserEmail },
                new SqlParameter("@AssignedNumber", SqlDbType.NVarChar, 10) { Value = request.AssignedNumber },
                new SqlParameter("@MessagingUserType", SqlDbType.NVarChar, 50) { Value = request.MessagingUserType ?? (object)DBNull.Value },
                new SqlParameter("@IsActive", SqlDbType.Bit) { Value = request.IsActive },
                new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 100) { Value = "System" },
                new SqlParameter("@CreatedDate", SqlDbType.DateTime) { Value = DateTime.Now },
                new SqlParameter("@LastModifiedBy", SqlDbType.NVarChar, 100) { Value = "System" },
                new SqlParameter("@LastModifiedDate", SqlDbType.DateTime) { Value = DateTime.Now },
                new SqlParameter("@IsDeleted", SqlDbType.Bit) { Value = false }
        };


            var result = await _repository.StoredProcedureCommandAsync("InsertMessagingUser", parameters);


            var response = new Response<int>(result);

            return response;

        }
    }
}