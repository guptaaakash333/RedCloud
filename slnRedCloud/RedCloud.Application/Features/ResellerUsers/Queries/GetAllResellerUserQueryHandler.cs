using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.OrganizationAdmins.Queries;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.ResellerUsers.Queries
{
    public class GetAllResellerUserQueryHandler : IRequestHandler<GetAllResellerUserQuery, Response<IEnumerable<ResellerUserVM>>>
    {

        private readonly ILogger<GetAllResellerUserQueryHandler> _logger;
        private readonly IAsyncRepository<ResellerUser> _asyncRepository;
        private readonly IMapper _mapper;

        public GetAllResellerUserQueryHandler(ILogger<GetAllResellerUserQueryHandler> logger, IAsyncRepository<ResellerUser> asyncRepository, IMapper mapper)
        {
            _logger = logger;
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<ResellerUserVM>>> Handle(GetAllResellerUserQuery request, CancellationToken cancellationToken)
        {
            // _logger.LogInformation("Handle Initiated");
            var allResellerUser = (await _asyncRepository.ListAllAsync()).Where(x => x.IsDeleted == false);
            var allResellerUsers = _mapper.Map<IEnumerable<ResellerUserVM>>(allResellerUser);
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<ResellerUserVM>>(allResellerUsers , "success");

        }
    }
}
