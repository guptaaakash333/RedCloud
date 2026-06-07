using MediatR;


using RedCloud.Application.Responses;
using RedCloud.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Account.Queries.LoginQuery
{
    public class LoginQuery : IRequest<Response<UserVM>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

}
