using RedCloud.Application.Features.MessagingUsers.Commands;
using RedCloud.Application.Features.MessagingUsers.Queries;
using RedCloud.Domain.Entities;
using RedCloud.ViewModel;

namespace RedCloud.Interfaces
{
    public interface IMessagingUserService
    {
        Task<IEnumerable<MessagingUsersVM>> GetAllMessagingUsers();
     
        Task<MessagingUsersVM> GetMessagingUserById(int id);
        Task<MessagingUsersVM> BlockMessagingUser(int Id);
        Task<bool> AddMessagingUser(MessagingUser messaginguser);

        Task<bool> UpdateMessagingUser(UpdateMessagingUserQuery updatemessaginguserquery);

    }
}
