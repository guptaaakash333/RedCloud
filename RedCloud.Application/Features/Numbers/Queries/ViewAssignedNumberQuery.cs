using MediatR;
using RedCloud.Application.Features.ResellerAdminuser.Queries;
using RedCloud.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Numbers.Queries
{
    public  class ViewAssignedNumberQuery : IRequest<Response<ViewAssignedNumberVM>>
    {

        public int Id { get; set; }


    }

}
