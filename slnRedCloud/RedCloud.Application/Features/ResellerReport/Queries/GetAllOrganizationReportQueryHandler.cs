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
    public class GetAllOrganizationReportQueryHandler: IRequestHandler<GetAllOrganizationReportQuery, Response<IEnumerable<OrganizationReportVM>>>
    {
    private readonly IAsyncRepository<ResellerInboundMessagesReport> _reportRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetOrganizationReportQueryHandler> _logger;

    public GetAllOrganizationReportQueryHandler(IAsyncRepository<ResellerInboundMessagesReport> reportRepository, IMapper mapper, ILogger<GetOrganizationReportQueryHandler> logger)
    {
        _reportRepository = reportRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Response<IEnumerable<OrganizationReportVM>>> Handle(GetAllOrganizationReportQuery request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Fetching organization report data");

            // Fetch data using ResellerInboundMessagesReport entity
            var reportData = await _reportRepository.StoredProcedureQueryAsync("GetFullOrganizationDetailsWithStatus");

            // Map reportData to OrganizationReportVM using AutoMapper if necessary
            var mappedData = _mapper.Map<IEnumerable<OrganizationReportVM>>(reportData);

            return new Response<IEnumerable<OrganizationReportVM>>(mappedData, "Fetched successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching organization report data");
            return new Response<IEnumerable<OrganizationReportVM>>(null, "An error occurred");
        }
    }

}
}

