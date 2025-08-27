using F1ApiBase.Models;
using F1ApiBase.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace F1ApiBase.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PilotosController : ControllerBase
    {
        private readonly IPilotoService _pilotoService;
        private readonly ILogger<PilotosController> _logger;

        public PilotosController(IPilotoService pilotoService, ILogger<PilotosController> logger)
        {
            _pilotoService = pilotoService;
            _logger = logger;
        }

        // GET ALL: 200 OK
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var pilotos = _pilotoService.GetAllPilotos();
                return Ok(pilotos); // 200 OK
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener pilotos");
                return Problem("Ocurrió un error al obtener los pilotos.", statusCode: 500);
            }
        }

        // GET BY ID: 200 OK o 404 Not Found
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var piloto = _pilotoService.GetPilotoById(id);
                if (piloto == null) return NotFound(new { message = "Piloto no encontrado" }); // 404 Not Found
                return Ok(piloto); // 200 OK
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener piloto {Id}", id);
                return Problem("Ocurrió un error al obtener el piloto.", statusCode: 500);
            }
        }

        // POST: 201 Created o 400 Bad Request
        [HttpPost]
        public IActionResult Create([FromBody] Piloto piloto)
        {
            try
            {
                if (!ModelState.IsValid) return ValidationProblem(ModelState); // 400 Bad Request

                _pilotoService.AddPiloto(piloto);
                return CreatedAtAction(nameof(GetById), new { id = piloto.Id }, piloto); // 201 Created
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear piloto");
                return Problem("Ocurrió un error al crear el piloto.", statusCode: 500);
            }
        }

        // PUT: 200 OK, 400 Bad Request, 404 Not Found
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] Piloto piloto)
        {
            try
            {
                if (!ModelState.IsValid) return ValidationProblem(ModelState); // 400 Bad Request
                if (id <= 0) return BadRequest(new { message = "Id inválido" }); // 400 Bad Request

                piloto.Id = id;

                var success = _pilotoService.UpdatePiloto(piloto);
                if (!success) return NotFound(new { message = "Piloto no encontrado" }); // 404 Not Found

                return Ok(piloto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar piloto {Id}", id);
                return Problem("Ocurrió un error al actualizar el piloto.", statusCode: 500);
            }
        }

        // DELETE: 204 No Content, 404 Not Found
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var success = _pilotoService.DeletePiloto(id);
                if (!success) return NotFound(new { message = "Piloto no encontrado" });// 404 Not Found

                return NoContent(); //204 No Content
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar piloto {Id}", id);
                return Problem("Ocurrió un error al eliminar el piloto.", statusCode: 500);
            }
        }
    }
}