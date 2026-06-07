using MediatR;
using RedCloud.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.OrganizationAdmins.Queries
{
    public class GetAllOrganizationAdminQuery : IRequest<Response<IEnumerable<GetAllOrganizationAdminVM>>>
    {


    }

}
