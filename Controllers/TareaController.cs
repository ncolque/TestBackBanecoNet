using Microsoft.AspNetCore.Mvc;
using TestBackBanecoNet.Entities;
using TestBackBanecoNet.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestBackBanecoNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly TareaService _service;

        public TareaController()
        {
            _service = new TareaService();
        }

        // GET: api/<TareaController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var tareas = await _service.ObtenerTodasAsync();
                return Ok(tareas);
            }
            catch
            {
                return StatusCode(500, "Error al obtener las tareas.");
            }
        }

        // GET api/<TareaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var tarea = await _service.ObtenerPorIdAsync(id);
                if (tarea == null)
                    return NotFound("No se encontró la tarea.");

                return Ok(tarea);
            }
            catch
            {
                return StatusCode(500, "Error al obtener la tarea.");
            }
        }

        // POST api/<TareaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Tarea tarea)
        {
            try
            {
                if (tarea == null)
                    return BadRequest("Datos invalidos.");

                var nueva = await _service.CrearAsync(tarea);
                return CreatedAtAction(nameof(Get), new { id = nueva.Id }, nueva);
            }
            catch
            {
                return StatusCode(500, "Error al crear la tarea.");
            }
        }

        // PUT api/<TareaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Tarea tareaActualizada)
        {
            try
            {
                var actualizada = await _service.ActualizarAsync(id, tareaActualizada);
                if (actualizada == null)
                    return NotFound("No se encontro la tarea para actualizar.");

                return Ok(actualizada);
            }
            catch
            {
                return StatusCode(500, "Error al actualizar la tarea.");
            }
        }

        // DELETE api/<TareaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var eliminado = await _service.EliminarAsync(id);
                if (!eliminado)
                    return NotFound(new { mensaje = "No se encontro la tarea para eliminar." });

                return Ok(new { mensaje = $"Tarea con ID {id} eliminada correctamente." });
            }
            catch
            {
                return StatusCode(500, new { mensaje = "Error al eliminar la tarea." });
            }
        }
    }
}