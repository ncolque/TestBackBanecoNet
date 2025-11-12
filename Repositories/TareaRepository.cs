using System.Text.Json;
using TestBackBanecoNet.Entities;

namespace TestBackBanecoNet.Repositories
{
    public class TareaRepository
    {
        private readonly string nombreArchivo = "tareas.json";

        public async Task<List<Tarea>> ObtenerTareasAsync()
        {
            if (!File.Exists(nombreArchivo))
                return new List<Tarea>();

            string jsonString = await File.ReadAllTextAsync(nombreArchivo);
            return JsonSerializer.Deserialize<List<Tarea>>(jsonString) ?? new List<Tarea>();
        }

        public async Task GuardarTareasAsync(List<Tarea> tareas)
        {
            string jsonString = JsonSerializer.Serialize(tareas, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(nombreArchivo, jsonString);
        }
    }
}
