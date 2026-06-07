using RedCloud.Domain.Entities;

namespace RedCloud.ViewModel
{
    public class FullOrgReportVM
    {
        public IEnumerable<ResellerInboundMessagesReport> ResellerInboundMessagesReports { get; set; }
        public IEnumerable<TotalReport> TotalReports { get; set; }

        public string OrgName { get; set; }
        public string OrgAdminMobNo { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }

        public int TotalUsers { get; set; }
        public int TotalNumbers { get; set; }
        public int TotalInboundSMS { get; set; }
        public int TotalOutboundSMS { get; set; }
        public int TotalInboundMMS { get; set; }
        public int TotalOutboundMMS { get; set; }
    }
}
