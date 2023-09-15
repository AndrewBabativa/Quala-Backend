using Quala.Models;

namespace Quala.Interfaces
{
    public interface IMonedaRepository
    {
        IEnumerable<MonedaDTO> GetAll();
        MonedaDTO GetById(int id);
        MonedaDTO Create(MonedaDTO moneda);
        MonedaDTO Update(int id, MonedaDTO moneda);
        bool Delete(int id);
    }
}
