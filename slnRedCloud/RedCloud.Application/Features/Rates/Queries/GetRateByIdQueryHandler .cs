using AutoMapper;

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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RedCloud.Application.Features.Rates.Queries
{

    public class GetRateByIdQueryHandler : IRequestHandler<GetRateByIdQuery, Response<Rate>>
    {
        private readonly IAsyncRepository<Rate> _repository;
      

        public GetRateByIdQueryHandler(IAsyncRepository<Rate> repository)
        {
            _repository = repository;
           
        }

        public async Task<Response<Rate>> Handle(GetRateByIdQuery request, CancellationToken cancellationToken)
        {
            var parameters = new[]
            {
                new SqlParameter("@Id", request.Id),
            };

            try
            {
                var Res = (await _repository.StoredProcedureQueryAsync("usp_GetRateById", parameters)).FirstOrDefault();

                if (Res == null)
                {
                    return new Response<Rate>("Rate not found");
                }

                return new Response<Rate>(Res, "Rate retrieved successfully");
            }
            catch (Exception ex)
            {
                return new Response<Rate>($"Error retrieving rate by Id: {ex.Message}");
            }
        }
    }




}