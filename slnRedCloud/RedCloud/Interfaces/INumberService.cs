using RedCloud.Application.Features.Numbers.Commands;
using RedCloud.Application.Features.Numbers.Queries;
using RedCloud.Domain.Entities;
using RedCloud.ViewModel;

namespace RedCloud.Interfaces
{
    public interface INumberService<T>
    {

        Task<int> AddNumber(NumberVM numberVM);
        Task<AssignNumberViewModel> GetNumberById(int eventId);

        Task UpdateNumber(AssignNumberViewModel assignNumberViewModel);



        Task<IEnumerable<NumberlistVM>> Getallnumberslist();

        Task<RedCloud.Application.Features.Numbers.Queries.ViewAssignedNumberVM> GetAssignedNumberById(int eventId);


       Task UpdateAssignedNumber(RedCloud.Application.Features.Numbers.Queries.ViewAssignedNumberVM assignNumberViewModel);

        Task UpdateProgress(NumberlistVM numberlistVM); 
    }
}
