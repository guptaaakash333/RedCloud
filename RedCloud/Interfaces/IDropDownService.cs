using RedCloud.Domain.Entities;
using RedCloud.ViewModel;

namespace RedCloud.Interfaces
{
  
public interface IDropDownService<T>
    {

        Task<IEnumerable<CountryVM>> GetAllCountryList();
    }
}
