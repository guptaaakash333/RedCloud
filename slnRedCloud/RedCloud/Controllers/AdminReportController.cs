using Microsoft.AspNetCore.Mvc;
using RedCloud.Interfaces;
using RedCloud.ViewModel;

namespace RedCloud.Controllers
{
    public class AdminReportController : Controller
    {
        private readonly IAdminReport _report;

        public AdminReportController(IAdminReport report)
        {
            _report = report;
        }

        [HttpGet]
        public async Task<IActionResult> ViewInboundReport()
        {

            var response = await _report.GetAdminInboundMessagesReport();

            return View(response);
        }


        [HttpGet]
        public async Task<IActionResult> ViewOutboundReport()
        {

            var response = await _report.GetAdminOutboundMessagesReport();

            return View(response);
        }



        [HttpGet]
        public async Task<IActionResult> ViewFullAdminReport()
        {
            try
            {
                var totalReports = await _report.GetAdminTotalReportCount();
                var resellerInboundMessagesReports = await _report.ViewFullAdminReport();

                // Check data here
                if (totalReports == null || !totalReports.Any())
                {
                    throw new Exception("Total reports data is empty.");
                }

                if (resellerInboundMessagesReports == null || !resellerInboundMessagesReports.Any())
                {
                    throw new Exception("Reseller inbound messages reports data is empty.");
                }

                var model = resellerInboundMessagesReports.Select(report => new FullResReportVM
                {
                    OrgName = report.OrgName,
                    OrgAdminMobNo = report.OrgAdminMobNo,
                    CreatedDateTime = report.CreatedDateTime,
                    Type = report.Type,
                    Status = report.Status,
                    TotalResellers = totalReports.FirstOrDefault()?.TotalResellers ?? 0, 
                    TotalNumbers = totalReports.FirstOrDefault()?.TotalNumbers ?? 0, 
                    TotalOrganizations = totalReports.FirstOrDefault()?.TotalOrganizations ?? 0, 
                    TotalTollfreeNumbers = totalReports.FirstOrDefault()?.TotalTollfreeNumbers ?? 0, 
                    
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