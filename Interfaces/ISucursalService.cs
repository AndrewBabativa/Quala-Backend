using Quala.Models;

namespace Quala.Interfaces
{
    public interface ISucursalService
    {
        IEnumerable<SucursalDTO> GetAllSucursales();
        SucursalDTO GetSucursalById(int id);
        SucursalDTO CreateSucursal(SucursalDTO sucursalDto);
        SucursalDTO UpdateSucursal(int id, SucursalDTO sucursalDto);
        SucursalDTO DeleteSucursal(int id);
    }
}
