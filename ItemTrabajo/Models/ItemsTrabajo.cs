namespace ItemTrabajo.Models
{
    public class ItemsTrabajo
    {
        public int IdItem { get; set; }

        public string Titulo { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaEntrega { get; set; }

        public string Relevancia { get; set; } = string.Empty;

        public string Estado { get; set; } = string.Empty;

        public string? UsuarioAsignado { get; set; }

        public DateTime? FechaCompletado { get; set; }
    }
}
