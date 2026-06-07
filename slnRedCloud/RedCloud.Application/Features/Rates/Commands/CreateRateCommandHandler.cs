using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.RedCloudAdmins.Commands.CreateRedCloudAdmin;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Rates.Commands
{
   

    public class CreateRateCommandHandler : IRequestHandler<CreateRateCommand, Response<int>>
    {
        private readonly IAsyncRepository<Rate> _repository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateRateCommandHandler(IAsyncRepository<Rate> repository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Response<int>> Handle(CreateRateCommand request, CancellationToken cancellationToken)
        {
           // var userId = _httpContextAccessor.HttpContext.Session.GetInt32("UserId");
            var parameters = new[]
            {
            
            new SqlParameter("@ResellerAdminUserId", SqlDbType.Int) { Value = request.ResellerAdminUserId },
            new SqlParameter("@ResellerName", SqlDbType.VarChar, 50) { Value = request.ResellerName },
            new SqlParameter("@Type", SqlDbType.VarChar, 50) { Value = request.Type },
            new SqlParameter("@InboundSMS", SqlDbType.Int) { Value = request.InboundSMS },
            new SqlParameter("@OutboundSMS", SqlDbType.Int) { Value = request.OutboundSMS },
            new SqlParameter("@InboundMMS", SqlDbType.Int) { Value = request.InboundMMS },
            new SqlParameter("@OutboundMMS", SqlDbType.Int) { Value = request.OutboundMMS },
            new SqlParameter("@MonthlyNumber", SqlDbType.Int) { Value = request.MonthlyNumber },
            new SqlParameter("@Users", SqlDbType.Int) { Value = request.Users },
            new SqlParameter("@CreatedBy", SqlDbType.Int) { Value = request.CreatedBy },
            new SqlParameter("@LastModifiedBy", SqlDbType.Int) { Value = 0}, 
            new SqlParameter("@IsDeleted", SqlDbType.Bit) { Value = false }
        };


        var result = await _repository.StoredProcedureCommandAsync("usp_InsertRate", parameters);

            
            var response = new Response<int>(result);
            
            return response;

        }
    }
}