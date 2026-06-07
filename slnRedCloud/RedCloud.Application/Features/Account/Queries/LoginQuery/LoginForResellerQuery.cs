using MediatR;
using RedCloud.Application.Features.ResellerAdminuser.Queries;
using RedCloud.Application.Responses;
using RedCloud.Domain.Common;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Account.Queries.LoginQuery
{
    public class LoginForResellerQuery: IRequest<Response<UserVM>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
