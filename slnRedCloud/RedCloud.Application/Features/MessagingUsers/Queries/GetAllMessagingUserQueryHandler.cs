using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.MessagingUsers.Queries;
using RedCloud.Application.Features.OrganizationUsers.Queries;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.MessagingUsers.Queries
{
    public class GetAllMessagingUserQueryHandler : IRequestHandler<GetAllMessagingUserQuery, Response<IEnumerable<MessagingUserVM>>>
    {


        private readonly ILogger<GetAllMessagingUserQueryHandler> _logger;
        private readonly IAsyncRepository<MessagingUser> _asyncRepository;
        private readonly IMapper _mapper;

        public GetAllMessagingUserQueryHandler(ILogger<GetAllMessagingUserQueryHandler> logger, IAsyncRepository<MessagingUser> asyncRepository, IMapper mapper)
        {
            _logger = logger;
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<MessagingUserVM>>> Handle(GetAllMessagingUserQuery request, CancellationToken cancellationToken)
        {
            // _logger.LogInformation("Handle Initiated");
            var allMessagingUsers = (await _asyncRepository.ListAllAsync()).Where(x => x.IsDeleted == false);
            var messagingUser = _mapper.Map<IEnumerable<MessagingUserVM>>(allMessagingUsers);
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<MessagingUserVM>>(messagingUser, "success");

        }




    }
}
