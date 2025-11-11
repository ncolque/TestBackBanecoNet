using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading;
using TestBackBanecoNet.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestBackBanecoNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly string nombreArchivo = "tareas.json";

        // GET: api/<TareaController>
        [HttpGet]
        public async Task<ActionResult<List<Tarea>>> Get()
        {
            List<Tarea> tareas = new List<Tarea>();

            if (System.IO.File.Exists(nombreArchivo))
            {
                string jsonString = await System.IO.File.ReadAllTextAsync(nombreArchivo);
                tareas = JsonSerializer.Deserialize<List<Tarea>>(jsonString) ?? new List<Tarea>();
            }
            else
            {
                return NotFound("El archivo .json no existe.");
            }
            return Ok(tareas);
        }

        // GET api/<TareaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (System.IO.File.Exists(nombreArchivo))
            {
                string jsonString = await System.IO.File.ReadAllTextAsync(nombreArchivo);
                var tareas = JsonSerializer.Deserialize<List<Tarea>>(jsonString);
                var tarea = tareas.FirstOrDefault(t => t.Id == id);

                if (tarea != null)
                {
                    return Ok(tarea);
                }
            }
            else
            {
                return NotFound("El archivo .json no existe.");
            }

            return NotFound();
        }

        // POST api/<TareaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Tarea tarea)
        {
            List<Tarea> tareas = new List<Tarea>();

            if (System.IO.File.Exists(nombreArchivo))
            {
                string jsonString = await System.IO.File.ReadAllTextAsync(nombreArchivo);
                tareas = JsonSerializer.Deserialize<List<Tarea>>(jsonString) ?? new List<Tarea>();
            }
            else
            {
                tareas = new List<Tarea>();
            }

            if (tareas.Any())
            {
                tarea.Id = tareas.Max(t => t.Id) + 1;
            }
            else
            {
                tarea.Id = 1;
            }

            tareas.Add(tarea);

            string updateJsonString = JsonSerializer.Serialize(tareas, new JsonSerializerOptions { WriteIndented = true });
            await System.IO.File.WriteAllTextAsync(nombreArchivo, updateJsonString);

            return Ok(tarea);            
        }

        // PUT api/<TareaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Tarea tareaActualizada)
        {
            if (!System.IO.File.Exists(nombreArchivo))
            {
                return NotFound("El archivo .json no existe.");
            }

            string jsonString = await System.IO.File.ReadAllTextAsync(nombreArchivo);
            var tareas = JsonSerializer.Deserialize<List<Tarea>>(jsonString);
            var tareaExistente = tareas.FirstOrDefault(t => t.Id == id);

            if (tareaExistente == null)
            {
                return NotFound("No existe la tarea.");
            }

            tareaExistente.Titulo = tareaActualizada.Titulo;
            tareaExistente.Descripcion = tareaActualizada.Descripcion;
            tareaExistente.Estado = tareaActualizada.Estado;

            string updateJsonString = JsonSerializer.Serialize(tareas, new JsonSerializerOptions { WriteIndented = true });
            await System.IO.File.WriteAllTextAsync(nombreArchivo, updateJsonString);

            return Ok(tareaExistente);
        }

        // DELETE api/<TareaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!System.IO.File.Exists(nombreArchivo))
            {
                return NotFound("El archivo .json no existe.");
            }

            string jsonString = await System.IO.File.ReadAllTextAsync(nombreArchivo);
            var tareas = JsonSerializer.Deserialize<List<Tarea>>(jsonString);

            var tareaEliminar = tareas.FirstOrDefault(t => t.Id == id);

            if (tareaEliminar == null)
            {
                return NotFound("No existe la tarea.");
            }

            tareas.Remove(tareaEliminar);

            string updateJsonString = JsonSerializer.Serialize(tareas, new JsonSerializerOptions { WriteIndented = true });
            await System.IO.File.WriteAllTextAsync(nombreArchivo, updateJsonString);

            return Ok("Tarea eliminada.");
        }
    }
}