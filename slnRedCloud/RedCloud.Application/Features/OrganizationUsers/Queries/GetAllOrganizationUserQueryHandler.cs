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

namespace RedCloud.Application.Features.OrganizationUsers.Queries
{
    public class GetAllOrganizationUserQueryHandler : IRequestHandler<GetAllOrganizationUserQuery, Response<IEnumerable<GetAllOrganizationUserVM>>>
    {

        private readonly ILogger<GetAllOrganizationUserQueryHandler> _logger;
        private readonly IAsyncRepository<OrganizationUser> _asyncRepository;
        private readonly IMapper _mapper;

        public GetAllOrganizationUserQueryHandler(ILogger<GetAllOrganizationUserQueryHandler> logger, IAsyncRepository<OrganizationUser> asyncRepository, IMapper mapper)
        {
            _logger = logger;
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GetAllOrganizationUserVM>>> Handle(GetAllOrganizationUserQuery request, CancellationToken cancellationToken)
        {
            // _logger.LogInformation("Handle Initiated");
            var allOrganizationUser = (await _asyncRepository.ListAllAsync()).Where(x => x.IsDeleted == false);
            var OrganizationUser = _mapper.Map<IEnumerable<GetAllOrganizationUserVM>>(allOrganizationUser);
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<GetAllOrganizationUserVM>>(OrganizationUser, "success");

        }

     
    }
}
