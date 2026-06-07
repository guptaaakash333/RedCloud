using MediatR;
using Microsoft.Data.SqlClient;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Rates.Queries
{
    public class SoftDeleteRateQueryHandler: IRequestHandler<SoftDeleteRateQuery, Response<Rate>>
    {
        private readonly IAsyncRepository<Rate> _rateRepository;

    public SoftDeleteRateQueryHandler(IAsyncRepository<Rate> rateRepository)
    {
        _rateRepository = rateRepository;
    }

    public async Task<Response<Rate>> Handle(SoftDeleteRateQuery request, CancellationToken cancellationToken)
    {
           

            var parameters = new[]
                  {
                new SqlParameter("@Id", request.Id),
            };

            try
            {
                //var Res = (await _rateRepository.StoredProcedureQueryAsync("usp_SoftDeleteRateById", parameters)).FirstOrDefault();
                await _rateRepository.StoredProcedureQueryAsync("usp_SoftDeleteRateById", parameters);

                

                return new Response<Rate>("Rate retrieved successfully");
            }
            catch (Exception ex)
            {
                return new Response<Rate>($"Error retrieving rate by Id: {ex.Message}");
            }
        }
}
}
   

