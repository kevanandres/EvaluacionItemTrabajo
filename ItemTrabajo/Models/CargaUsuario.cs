namespace ItemTrabajo.Models
{
    /// <summary>
    /// Clase de cargas de usuario
    /// </summary>
    public class CargaUsuario
    {
        public string NombreUsuario { get; set; } = string.Empty;
        public int CantidadPendientes { get; set; }
        public int CantidadAltos { get; set; }
    }
}
