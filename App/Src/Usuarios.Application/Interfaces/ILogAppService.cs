using Usuarios.Application.ViewModels.Log;
using Usuarios.Domain.Core.Messaging;

namespace Usuarios.Application.Interfaces
{
    public interface ILogAppService : IDisposable
    {
        Task<CommandResponse> Crear(LogCrearViewModel modelo);
        Task<LogViewModel> BuscaPorId(Guid id);
        Task<LogViewModel> BuscaPorIdUsuario(Guid idUsuario);
        Task<LogViewModel> ObtieneUltimaAccionReportadaUsuario(Guid id);
    }
}
