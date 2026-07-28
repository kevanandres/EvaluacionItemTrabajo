namespace GestionUsuario.Models
{
    /// <summary>
    /// Clase que contiene todos los parametros que se van a manejar desde la tabla de la BDD
    /// </summary>
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
