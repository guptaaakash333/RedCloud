using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.Campaigns.Queries;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.AssignNumberToUser.Queries
{
    public class GetAllAssignNumberQueriesHandler : IRequestHandler<GetAllAssignNumberQueries, Response<IEnumerable<GetAllAssignNumber>>>
    {
        private readonly ILogger<GetAllAssignNumber> _logger;
        private readonly IAsyncRepository<GetAllAssignNumber> _asyncRepository;
        private readonly IMapper _mapper;


        public GetAllAssignNumberQueriesHandler(IAsyncRepository<GetAllAssignNumber> asyncRepository, ILogger<GetAllAssignNumber> logger, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<GetAllAssignNumber>>> Handle(GetAllAssignNumberQueries request, CancellationToken cancellationToken)
        {
            try
            {
                //_logger.LogInformation("Handle Initiated for GetAllAssignNumber");
                var allNumber = (await _asyncRepository.StoredProcedureQueryAsync("usp_GetAllAssignNumber")).ToList();
                
                //_logger.LogInformation("Hanlde Completed for GetAllAssignNumber");
                return new Response<IEnumerable<GetAllAssignNumber>>(allNumber, "success");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
