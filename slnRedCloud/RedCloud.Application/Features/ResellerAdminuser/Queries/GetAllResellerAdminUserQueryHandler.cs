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

namespace RedCloud.Application.Features.ResellerAdminuser.Queries
{
    public class GetAllResellerAdminUserQueryHandler : IRequestHandler<GetAllResellerAdminUserQuery, Response<IEnumerable<ResellerAdminUserVM>>>
    {
        private readonly ILogger<GetAllResellerAdminUserQueryHandler> _logger;
        private readonly IAsyncRepository<ResellerAdminUser> _asyncRepository;
        private readonly IMapper _mapper;


        public GetAllResellerAdminUserQueryHandler(IMapper mapper, ILogger<GetAllResellerAdminUserQueryHandler> logger, IAsyncRepository<ResellerAdminUser> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<ResellerAdminUserVM>>> Handle(GetAllResellerAdminUserQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allReSellerAdmin = (await _asyncRepository.ListAllAsync()).Where(x => x.IsDeleted == false);
            var resellerAdmin = _mapper.Map<IEnumerable<ResellerAdminUserVM>>(allReSellerAdmin);
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<ResellerAdminUserVM>>(resellerAdmin, "success");
        }


        //public async Task<Response<IEnumerable<ResellerAdminUserVM>>> Handle(GetAllResellerAdminUserQuery request, CancellationToken cancellationToken)
        //{
        //    _logger.LogInformation("Handle Initiated");
        //    var allReSellerAdmin = (await _asyncRepository.ListAllAsync()).Where(x => x.IsDeleted == false);
        //    var resellerAdmin = _mapper.Map<IEnumerable<ResellerAdminUserVM>>(allReSellerAdmin);
        //    _logger.LogInformation("Hanlde Completed");
        //    return new Response<IEnumerable<ResellerAdminUserVM>>(resellerAdmin, "success");
        //}


    }

}
