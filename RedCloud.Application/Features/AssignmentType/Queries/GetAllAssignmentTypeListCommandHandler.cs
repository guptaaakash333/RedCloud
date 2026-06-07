using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.Carrierss.Queries;
using RedCloud.Application.Features.Carrierss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedCloud.Application.Responses;

namespace RedCloud.Application.Features.AssignmentType.Queries
{
    public class GetAllAssignmentTypeListCommandHandler : IRequestHandler<GetAllAssignmentTypeListCommand, Response<IEnumerable<AssignmentTypeVM>>>

    {
        private readonly ILogger<GetAllAssignmentTypeListCommandHandler> _logger;
        private readonly IAsyncRepository<RedCloud.Domain.Entities.AssignmentType> _asyncRepository;
        private readonly IMapper _mapper;
        public GetAllAssignmentTypeListCommandHandler(IMapper mapper, ILogger<GetAllAssignmentTypeListCommandHandler> logger, IAsyncRepository<RedCloud.Domain.Entities.AssignmentType> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }




       

        public async Task<Response<IEnumerable<AssignmentTypeVM>>> Handle(GetAllAssignmentTypeListCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allassigntype = (await _asyncRepository.ListAllAsync()).ToList();
            var assignments = _mapper.Map<IEnumerable<AssignmentTypeVM>>(allassigntype);
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<AssignmentTypeVM>>(assignments, "success");
        }
    }
    
    
}
