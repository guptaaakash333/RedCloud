using RedCloud.Application.Features.AssignNumberToUser.Commands;
using RedCloud.Domain.Entities;

namespace RedCloud.Interfaces
{
    public interface IAssignNumberService
    {
        Task<IEnumerable<GetAllAssignNumber>> GetAllAssignNumber();

        Task<int> CreateAssignNumber(AssignNumberToUserCommand command);

        Task<GetAllAssignNumber> GetAssignNumberById(int id);
    }
}
