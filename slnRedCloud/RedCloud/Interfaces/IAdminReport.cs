using RedCloud.Domain.Entities;

namespace RedCloud.Interfaces
{
    public interface IAdminReport
    {
        Task<IEnumerable<AdminInboundMessageReport>> GetAdminInboundMessagesReport();
        Task<IEnumerable<AdminInboundMessageReport>> GetAdminOutboundMessagesReport();
        Task<IEnumerable<AdminInboundMessageReport>> ViewFullAdminReport();
        Task<IEnumerable<AdminCount>> GetAdminTotalReportCount();
    }
}
