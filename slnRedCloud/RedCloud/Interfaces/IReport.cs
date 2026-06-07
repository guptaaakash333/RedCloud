using RedCloud.Domain.Entities;

namespace RedCloud.Interfaces
{
    public interface IReport
    {
        Task<IEnumerable<ResellerInboundMessagesReport>> GetallResellerInboundMessagesReport();

        Task<IEnumerable<ResellerInboundMessagesReport>> GetOutboundResellerInboundMessagesReport();

        Task<IEnumerable<ResellerInboundMessagesReport>> GetFullResellerInboundMessagesReport();

        Task<IEnumerable<TotalReport>> GetTotalReportCount();
        
    }
}
