using MediatR;
using RedCloud.Application.Features.OrganizationUsers.Queries;
using RedCloud.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.MessagingUsers.Queries
{
    public class GetMessagingUserByIdQuery : IRequest<Response<MessagingUserVM>>
    {
        public int Id { get; set; }

        public GetMessagingUserByIdQuery(int id)
        {

           Id = id;

        }
    }
}
