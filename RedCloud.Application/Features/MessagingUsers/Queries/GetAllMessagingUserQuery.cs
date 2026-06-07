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
    public class GetAllMessagingUserQuery : IRequest<Response<IEnumerable<MessagingUserVM>>>
    {
    }
}
