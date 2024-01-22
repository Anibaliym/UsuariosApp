using Usuarios.Application.EventSourcedNormalizers.Usuario;
using Usuarios.Application.ViewModels.Usuario;
using Usuarios.Domain.Core.Messaging;

namespace Usuarios.Application.Interfaces
{
    public interface IUsuarioAppService : IDisposable
    {
        Task<CommandResponse> Crear(UsuarioCrearViewModel modelo);
        Task<CommandResponse> Modificar(UsuarioViewModel modelo);
        Task<CommandResponse> Eliminar(Guid id);

        Task<UsuarioViewModel> BuscaPorId(Guid id);
        Task<UsuarioViewModel> BuscaPorIdPersona(Guid idPersona);
        Task<UsuarioViewModel> BuscaPorNick(string nick);
        Task<IList<UsuarioViewModel>> ObtieneUsuariosEstadoActivo();
        Task<IList<UsuarioViewModel>> ObtieneUsuariosEstadoInactivo();

        Task<IList<UsuarioHistoryData>> GetAllHistory(Guid id);
    }
}
