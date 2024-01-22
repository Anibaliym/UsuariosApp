using AutoMapper;
using Usuarios.Application.EventSourcedNormalizers.Usuario;
using Usuarios.Application.Interfaces;
using Usuarios.Application.ViewModels.Usuario;
using Usuarios.Domain.Commands.Usuario.Commands;
using Usuarios.Domain.Core.Mediator;
using Usuarios.Domain.Core.Messaging;
using Usuarios.Domain.Interfaces;
using Usuarios.Infra.Data.PostgreSQL.Repository.EventSourcing;

namespace Usuarios.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _mediator;

        public UsuarioAppService(IMapper mapper, IUsuarioRepository usuarioRepository, IEventStoreRepository eventStoreRepository, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
            _eventStoreRepository = eventStoreRepository;
            _mediator = mediator;
        }

        public async Task<UsuarioViewModel> BuscaPorId(Guid id)
        {
            return _mapper.Map<UsuarioViewModel>(await _usuarioRepository.BuscaPorId(id));
        }

        public async Task<UsuarioViewModel> BuscaPorIdPersona(Guid idPersona)
        {
            return _mapper.Map<UsuarioViewModel>(await _usuarioRepository.BuscaPorIdPersona(idPersona));
        }

        public async Task<UsuarioViewModel> BuscaPorNick(string nick)
        {
            return _mapper.Map<UsuarioViewModel>(await _usuarioRepository.BuscaPorNick(nick));
        }

        public async Task<CommandResponse> Crear(UsuarioCrearViewModel modelo)
        {
            var createCommand = _mapper.Map<UsuarioCrearCommand>(modelo);
            return await _mediator.SendCommand(createCommand);
        }

        public async Task<CommandResponse> Eliminar(Guid id)
        {
            var deleteCommand = new UsuarioEliminarCommand(id);
            return await _mediator.SendCommand(deleteCommand);
        }

        public async Task<IList<UsuarioHistoryData>> GetAllHistory(Guid id)
        {
            return UsuarioHistory.ToJavaScriptCustomerHistory(await _eventStoreRepository.All(id));
        }

        public async Task<CommandResponse> Modificar(UsuarioViewModel modelo)
        {
            var updateCommand = _mapper.Map<UsuarioModificarCommand>(modelo);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<IList<UsuarioViewModel>> ObtieneUsuariosEstadoActivo()
        {
            return _mapper.Map<IList<UsuarioViewModel>>(await _usuarioRepository.ObtieneUsuariosEstadoActivo());
        }

        public async Task<IList<UsuarioViewModel>> ObtieneUsuariosEstadoInactivo()
        {
            return _mapper.Map<IList<UsuarioViewModel>>(await _usuarioRepository.ObtieneUsuariosEstadoInactivo());
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
