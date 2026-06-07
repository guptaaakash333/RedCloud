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
	public class GetTypeQueryHandler : IRequestHandler<GetTypeQuery, Response<IEnumerable<CreditsType>>>
	{
		private readonly IAsyncRepository<CreditsType> _repository;
		public GetTypeQueryHandler(IAsyncRepository<CreditsType> repository)
        {
            _repository = repository;
        }
		public async Task<Response<IEnumerable<CreditsType>>> Handle(GetTypeQuery request, CancellationToken cancellationToken)
		{
			var Res = (await _repository.StoredProcedureQueryAsync("usp_GetTypeList")).ToList();
			return new Response<IEnumerable<CreditsType>>(Res, "success");
		}
	}
}
