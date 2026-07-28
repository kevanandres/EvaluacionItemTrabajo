using ItemTrabajo.Models;

namespace ItemTrabajo.Clients
{
    public class UsuarioClient
    {
        private readonly HttpClient _httpClient;

        public UsuarioClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Usuario>> ObtenerActivosAsync()
        {
            var usuarios = await _httpClient
                .GetFromJsonAsync<IEnumerable<Usuario>>(
                    "api/Usuarios/activos"
                );

            return usuarios ?? Enumerable.Empty<Usuario>();
        }
    }
}
