using QualaServices.Models;

namespace QualaServices.Interfaces
{
    public interface ISucursal
    {
        Task<Sucursal> PostSucursal(Sucursal sucursal);
        Task<List<Sucursal>> GetSucursal();
        Task<List<Sucursal>> GetSucursalbyId(int sucursalId);
        Task<List<Sucursal>> PutSucursal(Sucursal sucursal);
        Task<Sucursal> DeleteSucursal(Sucursal sucursal);
        bool SucursalExists(int id);
    }
}
