using MvcApiCallingService.Helpers.ApiHelper;
using RedCloud.Application.Features.AdminReport.Queries;
using RedCloud.Application.Features.ResellerReport.Queries;
using RedCloud.Domain.Entities;
using RedCloud.Interfaces;

namespace RedCloud.Services
{
    public class AdminReportService : IAdminReport
    {
        private readonly IApiClient<AdminInboundMessageReport> _reportuser;
        private readonly IApiClient<ResellerReportVM> _client;
        private readonly IApiClient<AdminCount> _repo;


        public AdminReportService(IApiClient<AdminInboundMessageReport> reportuser, IApiClient<ResellerReportVM> client, IApiClient<AdminCount> repo)
        {
            _reportuser = reportuser;
            _client = client;
            _repo = repo;

        }
        public async Task<IEnumerable<AdminInboundMessageReport>> GetAdminInboundMessagesReport()
        {
            var report = await _reportuser.GetAllAsync("AdminReportApi/Inbound-Reseller-report");

            return report.Data;
        }

        public async Task<IEnumerable<AdminInboundMessageReport>> GetAdminOutboundMessagesReport()
        {
            var report = await _reportuser.GetAllAsync("AdminReportApi/outbound-Reseller-report");

            return report.Data;
        }

        public async Task<IEnumerable<AdminInboundMessageReport>> ViewFullAdminReport()
        {
            var report = await _reportuser.GetAllAsync("AdminReportApi/Full-Reseller-report");

            return report.Data;
        }

        public async Task<IEnumerable<AdminCount>> GetAdminTotalReportCount()
        {
            var report = await _repo.GetAllAsync("AdminReportApi/Total-Reseller-report");

            return report.Data;
        }
    }
}