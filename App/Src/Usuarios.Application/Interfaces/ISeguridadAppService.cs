using Usuarios.Application.EventSourcedNormalizers.Seguridad;
using Usuarios.Application.ViewModels.Seguridad;
using Usuarios.Domain.Core.Messaging;

namespace Usuarios.Application.Interfaces
{
    public interface ISeguridadAppService : IDisposable
    {
        Task<CommandResponse> Crear(SeguridadCrearViewModel modelo);
        Task<CommandResponse> Modificar(SeguridadModificarViewModel modelo);

        Task<SeguridadViewModel> BuscaPorId(Guid id);
        Task<SeguridadViewModel> BuscaPorIdUsuario(Guid idUsuario);
        Task<int> ObtieneIntentosPorId(Guid id);

        Task<IList<SeguridadHistoryData>> GetAllHistory(Guid id);
    }
}
