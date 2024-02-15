using AutoMapper;
using Usuarios.Application.EventSourcedNormalizers.Seguridad;
using Usuarios.Application.Interfaces;
using Usuarios.Application.ViewModels.Seguridad;
using Usuarios.Domain.Commands.Seguridad.Commands;
using Usuarios.Domain.Core.Mediator;
using Usuarios.Domain.Core.Messaging;
using Usuarios.Domain.Interfaces;
using Usuarios.Infra.Data.PostgreSQL.Repository.EventSourcing;

namespace Usuarios.Application.Services
{
    public class SeguridadAppService : ISeguridadAppService
    {
        private readonly IMapper _mapper;
        private readonly ISeguridadRepository _seguridadRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _mediator;

        public SeguridadAppService(IMapper mapper, ISeguridadRepository seguridadRepository, IEventStoreRepository eventStoreRepository, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _seguridadRepository = seguridadRepository;
            _eventStoreRepository = eventStoreRepository;
            _mediator = mediator;
        }

        public async Task<SeguridadViewModel> BuscaPorId(Guid id)
        {
            return _mapper.Map<SeguridadViewModel>(await _seguridadRepository.BuscaPorId(id));
        }

        public async Task<SeguridadViewModel> BuscaPorIdUsuario(Guid idUsuario)
        {
            return _mapper.Map<SeguridadViewModel>(await _seguridadRepository.BuscaPorIdUsuario(idUsuario));
        }

        public async Task<CommandResponse> Crear(SeguridadCrearViewModel modelo)
        {
            var createCommand = _mapper.Map<SeguridadCrearCommand>(modelo);
            return await _mediator.SendCommand(createCommand);
        }

        public async Task<CommandResponse> Modificar(SeguridadModificarViewModel modelo)
        {
            var updateCommand = _mapper.Map<SeguridadModificarCommand>(modelo);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<int> ObtieneIntentosPorId(Guid id)
        {
            return _mapper.Map<int>(await _seguridadRepository.ObtieneIntentosPorId(id));
        }

        public async Task<IList<SeguridadHistoryData>> GetAllHistory(Guid id)
        {
            return SeguridadHistory.ToJavaScriptCustomerHistory(await _eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
