using QualaServices.Models;

namespace QualaServices.Interfaces
{
    public interface IMoneda
    {
        Task<Monedum> PostMonedum(Monedum monedum);
        Task<List<Monedum>> GetMoneda();
        Task<List<Monedum>> GetMonedabyId(int monedaId);
        Task<List<Monedum>> PutMoneda(Monedum monedum);
        Task<Monedum> DeleteMoneda(Monedum monedum);
        bool MonedumExists(int id);
    }
}
