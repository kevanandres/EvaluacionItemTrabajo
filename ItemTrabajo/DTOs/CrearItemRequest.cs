namespace ItemTrabajo.DTOs
{
    /// <summary>
    /// Clase para el REQUEST de la creacion del ITEM
    /// </summary>
    public class CrearItemRequest
    {
        public string Titulo { get; set; } = string.Empty;
        public DateTime FechaEntrega { get; set; }
        public string Relevancia { get; set; } = string.Empty;
    }
}
