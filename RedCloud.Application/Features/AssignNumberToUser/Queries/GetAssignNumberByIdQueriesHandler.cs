using AutoMapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.AssignNumberToUser.Queries
{
    public class GetAssignNumberByIdQueriesHandler : IRequestHandler<GetAssignNumberByIdQueries, Response<GetAllAssignNumber>>
    {
        private readonly ILogger<GetAllAssignNumber> _logger;
        private readonly IAsyncRepository<GetAllAssignNumber> _asyncRepository;
        private readonly IMapper _mapper;

        public GetAssignNumberByIdQueriesHandler(IAsyncRepository<GetAllAssignNumber> asyncRepository, ILogger<GetAllAssignNumber> logger, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _logger = logger;
            _mapper = mapper;
        }


        public async Task<Response<GetAllAssignNumber>> Handle(GetAssignNumberByIdQueries request, CancellationToken cancellationToken)
        {
            var parameters = new[]
            {
                new SqlParameter("@NumberId",request.Id),
            };

            try
            {
                //_logger.LogInformation("Handle Initiated for GetAllAssignNumber");
                var allNumber = (await _asyncRepository.StoredProcedureQueryAsync("usp_GetAllAssignNumberById", parameters)).FirstOrDefault();

                //_logger.LogInformation("Hanlde Completed for GetAllAssignNumber");
                return new Response<GetAllAssignNumber>(allNumber, "success");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
