namespace Notas.Models
{
    public class Nota
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string? Contenido { get; set; }
    }
}