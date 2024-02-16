using MediatR;
using Usuarios.Domain.Commands.Log.Commands;
using Usuarios.Domain.Core.Messaging;
using Usuarios.Domain.Enumerations.Log;
using Usuarios.Domain.Events.Log.Events;

namespace Usuarios.Domain.Commands.Log.Handlers
{
    public partial class LogCommandHandler : IRequestHandler<LogCrearCommand, CommandResponse>
    {
        public async Task<CommandResponse> Handle(LogCrearCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.CommandResponse;

            var log = new Entities.Log(
                Guid.NewGuid(), 
                message.IdUsuario, 
                message.Accion, 
                message.Observacion, 
                message.FechaCreacion
            );

            var existeLog = await _logRepository.BuscaPorId(message.Id);

            if (existeLog != null)
            {
                AddError($"Ya existe el log para el usuario con el campo 'Id' '{message.IdUsuario}'. Operación Cancelada");
                return CommandResponse;
            }

            log.FechaCreacion = DateTime.Now;

            log.AddDomainEvent(new LogCrearEvent(
                log.Id,
                log.IdUsuario, 
                log.Accion, 
                log.Observacion, 
                log.FechaCreacion
            ));

            _logRepository.Crear(log);

            CommandResponse.Data = log;
            CommandResponse.Result = true;

            return await Commit(_logRepository.UnitOfWork);
        }
    }
}
