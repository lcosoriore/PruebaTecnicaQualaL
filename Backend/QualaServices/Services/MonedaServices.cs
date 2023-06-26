namespace QualaServices.Services
{
    using Microsoft.EntityFrameworkCore;
    using QualaServices.Interfaces;
    using QualaServices.Models;
    public class MonedaServices : IMoneda
    {
        private readonly QualaDbContext _context;

        public MonedaServices(QualaDbContext context)
        {
            _context = context;
        }
        public async Task<Monedum> PostMonedum(Monedum monedum)
        {
            try
            {
                _context.Add(monedum);
                await _context.SaveChangesAsync();

                return monedum;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error en insercion: {e.Message}  + inner {e.InnerException}");
                throw new Exception("Error en inserción de Monedum", e);
            }
        }

        public async Task<List<Monedum>> GetMoneda()
        {
            try
            {
                return await _context.Moneda.ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error en al obtener el listado de monedas: {e.Message}  + inner {e.InnerException}");
                throw new Exception("Error en inserción de Monedum", e);
            }
        }

        public async Task<List<Monedum>> GetMonedabyId(int monedaId)
        {
            try
            {
                var moneda = await _context.Moneda.FindAsync(monedaId);

                if (moneda == null)
                {
                    throw new Exception("La moneda no fue encontrada");
                }

                return new List<Monedum> { moneda };
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al obtener la moneda buscada: {e.Message} + inner {e.InnerException}");
                throw new Exception("Error al obtener la moneda");
            }
        }


        public async Task<List<Monedum>> PutMoneda(Monedum monedum)
        {
            try
            {
                if (MonedumExists(monedum.MonedaId))
                {
                    _context.Entry(monedum).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    var monedas = await _context.Moneda.ToListAsync();
                    return monedas;
                }
                else
                {
                    throw new Exception("La moneda no fue encontrada");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al actualizar la moneda: {e.Message} + inner {e.InnerException}");
                throw new Exception("Error al actualizar la moneda");
            }
        }

        public async Task<Monedum> DeleteMoneda(Monedum monedum)
        {
            try
            {
                _context.Moneda.Remove(monedum);
                await _context.SaveChangesAsync();

                return monedum;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al eliminar la moneda: {e.Message} + inner {e.InnerException}");
                throw new Exception("Error al eliminar la moneda");
            }
        }


        public bool MonedumExists(int id)
        {
            return (_context.Moneda?.Any(e => e.MonedaId == id)).GetValueOrDefault();
        }

    }
}
