using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.RedCloudAdmins.Commands.CreateRedCloudAdmin;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.RedCloudAdmins.Queries
{
    public  class GetAllRedCloudAdminQueryHandler : IRequestHandler<GetAllRedCloudAdminQuery, Response<IEnumerable<RedCloudAdminVM>>>

    {

            private readonly ILogger<GetAllRedCloudAdminQueryHandler> _logger;
            private readonly IAsyncRepository<RedCloudAdmin> _asyncRepository;
            private readonly IMapper _mapper;


            public GetAllRedCloudAdminQueryHandler(IMapper mapper, ILogger<GetAllRedCloudAdminQueryHandler> logger, IAsyncRepository<RedCloudAdmin> asyncRepository)
            {
                _asyncRepository = asyncRepository;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<Response<IEnumerable<RedCloudAdminVM>>> Handle(GetAllRedCloudAdminQuery request, CancellationToken cancellationToken)
            {
                _logger.LogInformation("Handle Initiated");
                var allReSellerAdmin = (await _asyncRepository.ListAllAsync()).Where(x => x.IsDeleted == false);
                var resellerAdmin = _mapper.Map<IEnumerable<RedCloudAdminVM>>(allReSellerAdmin);
                _logger.LogInformation("Hanlde Completed");
                return new Response<IEnumerable<RedCloudAdminVM>>(resellerAdmin, "success");
            }

        }
}
