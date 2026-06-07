using MediatR;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.RedCloudAdmins.Queries
{
    public class GetRedCloudAdminByIdQuery : IRequest<Response<RedCloudAdmin>>
    {
        public int RedCloudAdminUserId { get; set; }
    }
}
