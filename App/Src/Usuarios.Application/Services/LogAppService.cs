using AutoMapper;
using Usuarios.Application.Interfaces;
using Usuarios.Application.ViewModels.Log;
using Usuarios.Domain.Commands.Log.Commands;
using Usuarios.Domain.Core.Mediator;
using Usuarios.Domain.Core.Messaging;
using Usuarios.Domain.Interfaces;
using Usuarios.Infra.Data.PostgreSQL.Repository.EventSourcing;

namespace Usuarios.Application.Services
{
    public class LogAppService : ILogAppService
    {
        private readonly IMapper _mapper;
        private readonly ILogRepository _logRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _mediator;

        public LogAppService(IMapper mapper, ILogRepository logRepository, IEventStoreRepository eventStoreRepository, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _logRepository = logRepository;
            _eventStoreRepository = eventStoreRepository;
            _mediator = mediator;
        }

        public async Task<LogViewModel> BuscaPorId(Guid id)
        {
            return _mapper.Map<LogViewModel>(await _logRepository.BuscaPorId(id));
        }

        public async Task<LogViewModel> BuscaPorIdUsuario(Guid idUsuario)
        {
            return _mapper.Map<LogViewModel>(await _logRepository.BuscaPorIdUsuario(idUsuario));
        }

        public async Task<CommandResponse> Crear(LogCrearViewModel modelo)
        {
            var createCommand = _mapper.Map<LogCrearCommand>(modelo);
            return await _mediator.SendCommand(createCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<LogViewModel> ObtieneUltimaAccionReportadaUsuario(Guid id)
        {
            return _mapper.Map<LogViewModel>(await _logRepository.ObtieneUltimaAccionReportadaUsuario(id));
        }

        //public async Task<IList<LogHistoryData>> GetAllHistory(Guid id)
        //{
        //    return SeguridadHistory.ToJavaScriptCustomerHistory(await _eventStoreRepository.All(id));
        //}
    }
}
