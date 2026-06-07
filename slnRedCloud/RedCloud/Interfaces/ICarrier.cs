using RedCloud.ViewModel;

namespace RedCloud.Interfaces
{
    public interface ICarrier<T>
    {
        Task<IEnumerable<CarrierVM>> GetAllCarriersList();
    }
}
