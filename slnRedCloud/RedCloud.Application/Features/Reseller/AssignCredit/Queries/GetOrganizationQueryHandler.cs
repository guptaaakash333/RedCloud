using MediatR;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Reseller.AssignCredit.Queries
{
	public class GetOrganizationQueryHandler : IRequestHandler<GetOrganizationQuery, Response<IEnumerable<OrganizationAdmin>>>
	{
		private readonly IAsyncRepository<OrganizationAdmin> _repository;
		public GetOrganizationQueryHandler(IAsyncRepository<OrganizationAdmin> repository)
		{
			_repository = repository;
		}
		public async Task<Response<IEnumerable<OrganizationAdmin>>> Handle(GetOrganizationQuery request, CancellationToken cancellationToken)
		{
			var Res = (await _repository.StoredProcedureQueryAsync("usp_GetOrganization")).ToList();
			return new Response<IEnumerable<OrganizationAdmin>>(Res, "success");
		}
	}
}
