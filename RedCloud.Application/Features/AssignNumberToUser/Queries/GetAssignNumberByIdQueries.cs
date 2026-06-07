using MediatR;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.AssignNumberToUser.Queries
{
    public class GetAssignNumberByIdQueries: IRequest<Response<GetAllAssignNumber>>
    {
        public int Id { get; set; }

        public GetAssignNumberByIdQueries(int id)
        {
            Id = id;
        }

    }
}
