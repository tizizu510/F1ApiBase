using Microsoft.AspNetCore.Mvc;
using F1ApiBase.Models;
using F1ApiBase.Services.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace F1ApiBase.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CircuitosController : ControllerBase
    {
        private readonly ICircuitoService _circuitoService;

        public CircuitosController(ICircuitoService circuitoService)
        {
            _circuitoService = circuitoService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var circuitos = _circuitoService.GetAllCircuitos();
                return Ok(circuitos); // 200
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); //400
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var circuitos = _circuitoService.GetCircuitoById(id);
                if (circuitos == null)
                {
                    return NotFound(); // 404
                }
                return Ok(circuitos); // 200
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); //400
            }
        }

        [HttpPost()]
        public IActionResult AddCircuito([FromBody] Circuito circuito)
        {
            try
            {
                var nuevoCircuito = _circuitoService.AddCircuito(circuito);
                return Ok(nuevoCircuito);// 200
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public IActionResult UpdateCircuito([FromBody] Circuito circuito)
        {
            try
            {
                var circuitoActualizado = _circuitoService.UpdateCircuito(circuito);
                if (!circuitoActualizado)
                {
                    return NotFound();// 404
                }
                return NoContent();//204
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCircuito(int id)
        {
            try
            {
                var circuitoEliminado = _circuitoService.DeleteCircuito(id);
                if (!circuitoEliminado)
                {
                    return NotFound();
                }
                return NoContent();//204
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
