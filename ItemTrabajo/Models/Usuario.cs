namespace ItemTrabajo.Models
{
    /// <summary>
    /// Clase de usuario
    /// </summary>
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public bool Activo { get; set; }
    }
}
