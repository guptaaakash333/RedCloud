using MvcApiCallingService.Helpers.ApiHelper;
using RedCloud.Application.Features.Rates.Queries;
using RedCloud.Application.Features.ResellerReport.Queries;
using RedCloud.Domain.Entities;
using RedCloud.Interfaces;

namespace RedCloud.Services
{
    public class ReportService : IReport
    {
        private readonly IApiClient<ResellerInboundMessagesReport> _reportuser;
        private readonly IApiClient<OrganizationReportVM> _client;
        private readonly IApiClient<TotalReport> _repo;


        public ReportService(IApiClient<ResellerInboundMessagesReport> reportuser, IApiClient<OrganizationReportVM> client, IApiClient<TotalReport> repo)
        {
            _reportuser = reportuser;
            _client = client;
            _repo = repo;

        }
        public async Task<IEnumerable<ResellerInboundMessagesReport>> GetallResellerInboundMessagesReport()
        {
            var report = await _reportuser.GetAllAsync("ReportApi");

            return report.Data;
        }

        public async Task<IEnumerable<ResellerInboundMessagesReport>> GetOutboundResellerInboundMessagesReport()
        {
            var report = await _reportuser.GetAllAsync("ReportApi/outbound-organization-report");

            return report.Data;
        }

        public async Task<IEnumerable<ResellerInboundMessagesReport>> GetFullResellerInboundMessagesReport()
        {
            var report = await _reportuser.GetAllAsync("ReportApi/All-organization-report");

            return report.Data;
        }

        public async Task<IEnumerable<TotalReport>> GetTotalReportCount()
        {
            var report = await _repo.GetAllAsync("ReportApi/Total-organization-report");

            return report.Data;
        }
    }
}
