using System.ComponentModel.DataAnnotations;

namespace TestBackBanecoNet.Entities
{
    public enum TipoEstado
    {
        Pendiente,
        EnProgreso,
        Completada
    }
    public class Tarea
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El titulo es obligatorio.")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "La descripcion es obligatorio.")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El estado es obligatorio.")]
        [StringLength(12, ErrorMessage = "La descripción no puede superar los 12 caracteres.")]
        public string Estado { get; set; }
        //public TipoEstado Estado { get; set; }
    }
}
