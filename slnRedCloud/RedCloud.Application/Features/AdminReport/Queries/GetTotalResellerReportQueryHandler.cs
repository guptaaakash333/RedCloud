using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.ResellerReport.Queries;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.AdminReport.Queries
{
    public class GetTotalResellerReportQueryHandler : IRequestHandler<GetTotalResellerReportQuery, Response<IEnumerable<TotalReportVMs>>>
    {
        private readonly IAsyncRepository<AdminCount> _reportRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetTotalResellerReportQueryHandler> _logger;

        public GetTotalResellerReportQueryHandler(IAsyncRepository<AdminCount> reportRepository, IMapper mapper, ILogger<GetTotalResellerReportQueryHandler> logger)
        {
            _reportRepository = reportRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<TotalReportVMs>>> Handle(GetTotalResellerReportQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Fetching Reseller report data");


                var reportData = await _reportRepository.StoredProcedureQueryAsync("GetStatiStics");


                var mappedData = _mapper.Map<IEnumerable<TotalReportVMs>>(reportData);

                return new Response<IEnumerable<TotalReportVMs>>(mappedData, "Fetched successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching Reseller report data");
                return new Response<IEnumerable<TotalReportVMs>>(null, "An error occurred");
            }
        }
    }


}
    
