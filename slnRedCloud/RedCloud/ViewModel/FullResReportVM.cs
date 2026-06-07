using RedCloud.Domain.Entities;

namespace RedCloud.ViewModel
{
    public class FullResReportVM
    {
        public IEnumerable<AdminInboundMessageReport> AdminInboundMessagesReports { get; set; }
        public IEnumerable<AdminCount> TotalReports { get; set; }

        public string ResellerName { get; set; }
        public string OrgName { get; set; }
        public string OrgAdminMobNo { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }

        public int TotalResellers { get; set; }
        public int TotalOrganizations { get; set; }
        public int TotalNumbers { get; set; }
        public int TotalTollfreeNumbers { get; set; }
    }
}

