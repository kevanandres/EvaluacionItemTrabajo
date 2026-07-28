namespace ItemTrabajo.DTOs
{
    public class CrearItemRequest
    {
        public string Titulo { get; set; } = string.Empty;
        public DateTime FechaEntrega { get; set; }
        public string Relevancia { get; set; } = string.Empty;
    }
}
