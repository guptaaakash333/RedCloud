using RedCloud.ViewModel;

namespace RedCloud.Interfaces
{
    public interface IStateService<T>
    {
        Task<IEnumerable<StateVM>> GetStatesByCountryId(int Id);
    }
}
