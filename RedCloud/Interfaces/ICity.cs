using RedCloud.Domain.Entities;
using RedCloud.ViewModel;

namespace RedCloud.Interfaces
{
    public interface ICityService<T>
    {
        Task<IEnumerable<CityVM>> GetCityByStateId(int Id);
    }
}
