using RedCloud.ViewModel;

namespace RedCloud.Interfaces
{
    public interface IType<T>
    {
        Task<IEnumerable<TypesVM>> GetAllTypesList();
    }
}
