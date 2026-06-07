using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.OrganizationAdmins.Queries
{
    public class GetAllOrganizationAdminHandler : IRequestHandler<GetAllOrganizationAdminQuery, Response<IEnumerable<GetAllOrganizationAdminVM>>>
    {

        private readonly ILogger<GetAllOrganizationAdminHandler> _logger;
        private readonly IAsyncRepository<OrganizationAdmin> _asyncRepository;
        private readonly IMapper _mapper;

        public GetAllOrganizationAdminHandler(ILogger<GetAllOrganizationAdminHandler> logger, IAsyncRepository<OrganizationAdmin> asyncRepository, IMapper mapper)
        {
            _logger = logger;
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GetAllOrganizationAdminVM>>> Handle(GetAllOrganizationAdminQuery request, CancellationToken cancellationToken)
        {
            // _logger.LogInformation("Handle Initiated");
            var allOrganizationAdmin = (await _asyncRepository.ListAllAsync()).Where(x => x.IsDeleted == false);
            var OrganizationAdmin = _mapper.Map<IEnumerable<GetAllOrganizationAdminVM>>(allOrganizationAdmin);
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<GetAllOrganizationAdminVM>>(OrganizationAdmin, "success");

        }
    }
}
