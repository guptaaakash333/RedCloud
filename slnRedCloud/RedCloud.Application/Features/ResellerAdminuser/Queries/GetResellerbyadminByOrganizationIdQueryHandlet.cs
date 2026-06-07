using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.States;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace RedCloud.Application.Features.ResellerAdminuser.Queries
//{
//    public  class GetResellerbyadminByOrganizationIdQueryHandlet : IRequestHandler<GetResellerbyadminByOrganizationId, Response<IEnumerable<ResellerAdminUserVM>>>
//    {
//        private readonly ILogger<GetResellerbyadminByOrganizationIdQueryHandlet> _logger;
//        private readonly IAsyncRepository<ResellerAdminUser> _asyncRepository;
//        private readonly IMapper _mapper;
//    public GetResellerbyadminByOrganizationIdQueryHandlet(IMapper mapper, ILogger<GetResellerbyadminByOrganizationIdQueryHandlet> logger, IAsyncRepository<ResellerAdminUser> asyncRepository)
//    {
//        _asyncRepository = asyncRepository;
//        _mapper = mapper;
//        _logger = logger;
//    }
   

    

//        public async Task<Response<IEnumerable<ResellerAdminUserVM>>> Handle(GetResellerbyadminByOrganizationId request, CancellationToken cancellationToken)
//        {
//            _logger.LogInformation("Handle Initiated");
//            var list = (await _asyncRepository.ListAllAsync()).Where(x => x.== request.OrganizationAdminID).ToList();
//            _logger.LogInformation("Hanlde Completed");
//            return new Response<IEnumerable<State>>(list, "success");
//        }
//    }
   
//}
