using MediatR;
using RedCloud.Application.Features.Numbers.Commands;
using RedCloud.Application.Features.OrganizationAdmins.Queries;
using RedCloud.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Numbers.Queries
{
    public class AssignNumberQuery : IRequest<Response<AssignNumberViewModel>>
    {

        public int NumberId { get; set; }

        //public AssignNumberQuery(int id)
        //{
        //    Id = id;
        //}

    }
}
