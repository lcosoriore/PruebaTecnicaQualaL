using Microsoft.AspNetCore.Mvc;
using QualaServices.Interfaces;
using QualaServices.Models;

namespace QualaServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalsController : ControllerBase
    {
        ISucursal _sucursalServices;
        private readonly ILogger<MonedaController> _logger;

        public SucursalsController(ISucursal sucursal, ILogger<MonedaController> logger)
        {
            _sucursalServices = sucursal;
            _logger = logger;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sucursal>>> GetSucursals()
        {
            if (_sucursalServices is null)
            {
                return BadRequest("El servicio _sucursalServices no está inicializado correctamente");
            }
            var sucursales = await _sucursalServices.GetSucursal();
            if (sucursales == null)
            {
                return NoContent();
            }
            return Ok(sucursales);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sucursal>> GetSucursal(int id)
        {
            if (_sucursalServices is null)
            {
                return BadRequest("El servicio _sucursalServices no está inicializado correctamente");
            }
            var sucursales = await _sucursalServices.GetSucursalbyId(id);
            if (sucursales == null)
            {
                return NoContent();
            }
            return Ok(sucursales);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Sucursal>>> PutSucursal(int id, Sucursal sucursal)
        {
            try
            {
                return await _sucursalServices.PutSucursal(sucursal);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al actualizar la sucursal: {e.Message} + inner {e.InnerException}");
                return new BadRequestObjectResult("Error al actualizar la sucursal.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Sucursal>> PostSucursal(Sucursal sucursal)
        {
            try
            {

                await _sucursalServices.PostSucursal(sucursal);

                return Ok(sucursal);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error en insercion: {e.Message} + inner {e.InnerException}");
                return BadRequest("Error en la inserción de la sucursal");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSucursal(Sucursal sucursal)
        {
            try
            {
                await _sucursalServices.DeleteSucursal(sucursal);

                return Ok(sucursal);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error en eliminacion: {e.Message} + inner {e.InnerException}");
                return BadRequest("Error en la eliminacion de la Sucursal");
            }
        }

      
    }
}
