using MediatR;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.OrganizationUsers.Queries;
using RedCloud.Application.Features.ResellerUsers.Queries;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.MessagingUsers.Queries
{
    public class GetMessagingUserByIdQueryHandler : IRequestHandler<GetMessagingUserByIdQuery, Response<MessagingUserVM>>
    {

        private readonly IAsyncRepository<MessagingUser> _asyncRepository;
        public GetMessagingUserByIdQueryHandler(IAsyncRepository<MessagingUser> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }


        public async Task<Response<MessagingUserVM>> Handle(GetMessagingUserByIdQuery request, CancellationToken cancellationToken)
        {

            var user = await _asyncRepository.GetByIdAsyncInculde(request.Id);

            if (user == null)
            {
                return new Response<MessagingUserVM>("Messaging User not found");
            }

            var model = new MessagingUserVM()
            {
                MessagingUserId = request.Id,
                MessagingUserFirstName = user.MessagingUserFirstName,
                MessagingUserLastName = user.MessagingUserLastName,
                MessagingUserEmail = user.MessagingUserEmail,
                AssignedNumber = user.AssignedNumber,
                MessagingUserType = user.MessagingUserType,
                IsActive = user.IsActive
            };

            return new Response<MessagingUserVM>(model); ;
        }
    }
}
