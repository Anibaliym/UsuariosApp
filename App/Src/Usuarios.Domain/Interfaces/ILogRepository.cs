using Usuarios.Domain.Core.Data;
using Usuarios.Domain.Entities;

namespace Usuarios.Domain.Interfaces
{
    public interface ILogRepository : IRepository<Log>
    {
        void Crear(Log modelo);
        Task<Log> BuscaPorId(Guid id);
        Task<Log> BuscaPorIdUsuario(Guid idUsuario);
        Task<Log> ObtieneUltimaAccionReportadaUsuario(Guid id);
    }
}
