using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.ResellerReport.Queries
{
    public class GetTotalOrganizationReportQueryHandler : IRequestHandler<GetTotalOrganizationReportQuery, Response<IEnumerable<TotalReportVM>>>
    {
        private readonly IAsyncRepository<TotalReport> _reportRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetTotalOrganizationReportQuery> _logger;

        public GetTotalOrganizationReportQueryHandler(IAsyncRepository<TotalReport> reportRepository, IMapper mapper, ILogger<GetTotalOrganizationReportQuery> logger)
        {
            _reportRepository = reportRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<TotalReportVM>>> Handle(GetTotalOrganizationReportQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Fetching organization report data");

                // Fetch data using ResellerInboundMessagesReport entity
                var reportData = await _reportRepository.StoredProcedureQueryAsync("GetTotalOrganizationStatus");

                // Map reportData to OrganizationReportVM using AutoMapper if necessary
                var mappedData = _mapper.Map<IEnumerable<TotalReportVM>>(reportData);

                return new Response<IEnumerable<TotalReportVM>>(mappedData, "Fetched successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching organization report data");
                return new Response<IEnumerable<TotalReportVM>>(null, "An error occurred");
            }
        }

    }
}
