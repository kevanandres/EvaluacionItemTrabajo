using ItemTrabajo.Models;

namespace ItemTrabajo.DTOs
{
    /// <summary>
    /// Clase para el RESPONSE de la creacion del ITEM
    /// </summary>
    public class CrearItemResponse
    {
        public string UsuarioAsignado { get; set; } = string.Empty;
        
        public IEnumerable<ItemsTrabajo> PendientesOrdenados { get; set; } = Enumerable.Empty<ItemsTrabajo>();
    }
}
