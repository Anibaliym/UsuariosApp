using Usuarios.Domain.Core.Data;
using Usuarios.Domain.Entities;

namespace Usuarios.Domain.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        void Crear(Usuario modelo);
        void Modificar(Usuario modelo);
        void Eliminar(Usuario modelo);

        Task<Usuario> BuscaPorId(Guid id);
        Task<Usuario> BuscaPorIdPersona(Guid idPersona);
        Task<Usuario> BuscaPorNick(string nick);
        Task<IList<Usuario>> ObtieneUsuariosEstadoActivo();
        Task<IList<Usuario>> ObtieneUsuariosEstadoInactivo();
    }
}
