namespace TestBackBanecoNet.Entities
{
    public enum TipoEstado
    {
        Pendiente,
        Progreso,
        Completada
    }
    public class Tarea
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        //public TipoEstado Estado { get; set; }
    }
}
