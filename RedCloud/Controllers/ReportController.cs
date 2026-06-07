using Microsoft.AspNetCore.Mvc;
using RedCloud.Interfaces;
using RedCloud.Models;
using RedCloud.ViewModel;

namespace RedCloud.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReport _report;

        public ReportController(IReport report)
        {
            _report = report;
        }

        [HttpGet]
        public async Task<IActionResult> ViewInboundReport()
        {

            var response = await _report.GetallResellerInboundMessagesReport();

            return View(response);
        }


        [HttpGet]
        public async Task<IActionResult> ViewOutboundReport()
        {

            var response = await _report.GetOutboundResellerInboundMessagesReport();

            return View(response);
        }

       

        [HttpGet]
        public async Task<IActionResult> ViewFullOrgReport()
        {
            try
            {
                var totalReports = await _report.GetTotalReportCount();
                var resellerInboundMessagesReports = await _report.GetFullResellerInboundMessagesReport();

                // Check data here
                if (totalReports == null || !totalReports.Any())
                {
                    throw new Exception("Total reports data is empty.");
                }

                if (resellerInboundMessagesReports == null || !resellerInboundMessagesReports.Any())
                {
                    throw new Exception("Reseller inbound messages reports data is empty.");
                }

                var model = resellerInboundMessagesReports.Select(report => new FullOrgReportVM
                {
                    OrgName = report.OrgName,
                    OrgAdminMobNo = report.OrgAdminMobNo,
                    CreatedDate = report.CreatedDate,
                    Type = report.Type,
                    Status = report.Status,
                    TotalUsers = totalReports.FirstOrDefault()?.TotalUsers ?? 0, // Assuming TotalUsers is part of TotalReport
                    TotalNumbers = totalReports.FirstOrDefault()?.TotalNumbers ?? 0, // Assuming TotalNumbers is part of TotalReport
                    TotalInboundSMS = totalReports.FirstOrDefault()?.TotalInboundSMS ?? 0, // Assuming TotalInboundSMS is part of TotalReport
                    TotalOutboundSMS = totalReports.FirstOrDefault()?.TotalOutboundSMS ?? 0, // Assuming TotalOutboundSMS is part of TotalReport
                    TotalInboundMMS = totalReports.FirstOrDefault()?.TotalInboundMMS ?? 0, // Assuming TotalInboundMMS is part of TotalReport
                    TotalOutboundMMS = totalReports.FirstOrDefault()?.TotalOutboundMMS ?? 0 // Assuming TotalOutboundMMS is part of TotalReport
                }).ToList();

                return View(model);
            }
            catch (Exception ex)
            {
                return View(ex);

            }
        }



    }
}
