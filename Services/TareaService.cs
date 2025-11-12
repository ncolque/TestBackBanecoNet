using TestBackBanecoNet.Entities;
using TestBackBanecoNet.Repositories;

namespace TestBackBanecoNet.Services
{
    public class TareaService
    {
        private readonly TareaRepository _repository;

        public TareaService()
        {
            _repository = new TareaRepository();
        }

        public async Task<List<Tarea>> ObtenerTodasAsync()
        {
            return await _repository.ObtenerTareasAsync();
        }

        public async Task<Tarea?> ObtenerPorIdAsync(int id)
        {
            var tareas = await _repository.ObtenerTareasAsync();
            return tareas.FirstOrDefault(t => t.Id == id);
        }

        public async Task<Tarea> CrearAsync(Tarea nuevaTarea)
        {
            var tareas = await _repository.ObtenerTareasAsync();

            nuevaTarea.Id = tareas.Any() ? tareas.Max(t => t.Id) + 1 : 1;
            tareas.Add(nuevaTarea);

            await _repository.GuardarTareasAsync(tareas);
            return nuevaTarea;
        }

        public async Task<Tarea?> ActualizarAsync(int id, Tarea tareaActualizada)
        {
            var tareas = await _repository.ObtenerTareasAsync();
            var existente = tareas.FirstOrDefault(t => t.Id == id);

            if (existente == null) return null;

            existente.Titulo = tareaActualizada.Titulo;
            existente.Descripcion = tareaActualizada.Descripcion;
            existente.Estado = tareaActualizada.Estado;

            await _repository.GuardarTareasAsync(tareas);
            return existente;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var tareas = await _repository.ObtenerTareasAsync();
            var tarea = tareas.FirstOrDefault(t => t.Id == id);

            if (tarea == null) return false;

            tareas.Remove(tarea);
            await _repository.GuardarTareasAsync(tareas);
            return true;
        }
    }
}
