namespace QualaServices.Services
{
    using Microsoft.EntityFrameworkCore;
    using QualaServices.Interfaces;
    using QualaServices.Models;
    public class SucursalServices : ISucursal
    {
        private readonly QualaDbContext _context;
        public SucursalServices(QualaDbContext context)
        {
            _context = context;
        }
        public async Task<Sucursal> DeleteSucursal(Sucursal sucursal)
        {
            try
            {
                _context.Sucursals.Remove(sucursal);
                await _context.SaveChangesAsync();

                return sucursal;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al eliminar la sucursal: {e.Message} + inner {e.InnerException}");
                throw new Exception("Error al eliminar la sucursal");
            }
        }

        public async Task<List<Sucursal>> GetSucursal()
        {
            try
            {
                return await _context.Sucursals.ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error en al obtener el listado de sucursales: {e.Message}  + inner {e.InnerException}");
                throw new Exception("Error en al obtener el listado de sucursales", e);
            }
        }

        public async Task<List<Sucursal>> GetSucursalbyId(int sucursalId)
        {
            try
            {
                var sucursal = await _context.Sucursals.FindAsync(sucursalId);

                if (sucursal == null)
                {
                    throw new Exception("La Sucursal no fue encontrada");
                }

                return new List<Sucursal> { sucursal };
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al obtener la sucursal buscada: {e.Message} + inner {e.InnerException}");
                throw new Exception("Error al obtener la sucursal");
            }
        }

        public async Task<Sucursal> PostSucursal(Sucursal sucursal)
        {
            try
            {
                _context.Add(sucursal);
                await _context.SaveChangesAsync();

                return sucursal;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error en insercion: {e.Message}  + inner {e.InnerException}");
                throw new Exception("Error en inserción de sucursal", e);
            }
        }

        public async Task<List<Sucursal>> PutSucursal(Sucursal sucursal)
        {
            try
            {
                if (SucursalExists(sucursal.Codigo))
                {
                    _context.Entry(sucursal).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    var sucursales = await _context.Sucursals.ToListAsync();
                    return sucursales;
                }
                else
                {
                    throw new Exception("La Sucursal no fue encontrada");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al actualizar la sucursal: {e.Message} + inner {e.InnerException}");
                throw new Exception("Error al actualizar la sucursal");
            }
        }

        public bool SucursalExists(int id)
        {
            return (_context.Sucursals?.Any(e => e.Codigo == id)).GetValueOrDefault();
        }
    }
}
