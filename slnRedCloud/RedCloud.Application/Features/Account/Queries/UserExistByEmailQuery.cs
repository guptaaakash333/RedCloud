using MediatR;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Account.Queries
{
    public class UserExistByEmailQuery : IRequest<Response<User>>
    {
        public string Email { get; set; }
    }
}
