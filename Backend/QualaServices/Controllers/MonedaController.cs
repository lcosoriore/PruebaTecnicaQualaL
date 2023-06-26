
using Microsoft.AspNetCore.Mvc;
using QualaServices.Interfaces;
using QualaServices.Models;

namespace QualaServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonedaController : ControllerBase
    {
        IMoneda _monedaServices;
        private readonly ILogger<MonedaController> _logger;

        public MonedaController(IMoneda moneda, ILogger<MonedaController> logger)
        {
            _monedaServices = moneda;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<Monedum>>> GetMoneda()
        {
            if (_monedaServices is null)
            {
                return BadRequest("El servicio _monedaServices no está inicializado correctamente");
            }
            var monedas = await _monedaServices.GetMoneda();
            if (monedas == null)
            {
                return NoContent();
            }
            return Ok(monedas);
        }


        [HttpGet("{monedaId}")]
        public async Task<ActionResult<Monedum>> GetMonedum(int monedaId)
        {
            if (_monedaServices is null)
            {
                return BadRequest("El servicio _monedaServices no está inicializado correctamente");
            }
            var monedas = await _monedaServices.GetMonedabyId(monedaId);
            if (monedas == null)
            {
                return NoContent();
            }
            return Ok(monedas);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Monedum>>> PutMonedum( Monedum monedum)
        {
            try
            {
                return await _monedaServices.PutMoneda(monedum);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al actualizar la moneda: {e.Message} + inner {e.InnerException}");
                return new BadRequestObjectResult("Error al actualizar la moneda.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostMonedum(Monedum monedum)
        {
            try
            {
                
                await _monedaServices.PostMonedum(monedum);

                return Ok(monedum);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error en insercion: {e.Message} + inner {e.InnerException}");
                return BadRequest("Error en la inserción de la Moneda");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMonedum(Monedum monedum)
        {
            try
            {
                await _monedaServices.DeleteMoneda(monedum);

                return Ok(monedum);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error en eliminacion: {e.Message} + inner {e.InnerException}");
                return BadRequest("Error en la eliminacion de la Moneda");
            }
        }
        
    }
}
