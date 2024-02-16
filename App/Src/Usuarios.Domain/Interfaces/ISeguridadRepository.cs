using Usuarios.Domain.Core.Data;
using Usuarios.Domain.Entities;

namespace Usuarios.Domain.Interfaces
{
    public interface ISeguridadRepository : IRepository<Seguridad>
    {
        void Crear(Seguridad modelo);
        void Modificar(Seguridad modelo);
        Task<Seguridad> BuscaPorId(Guid id);
        Task<Seguridad> BuscaPorIdUsuario(Guid idUsuario);
        Task<int> ObtieneIntentosPorId(Guid id);
    }
}
