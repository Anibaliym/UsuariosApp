using MediatR;
using Usuarios.Domain.Commands.Seguridad.Commands;
using Usuarios.Domain.Core.Messaging;
using Usuarios.Domain.Events.Seguridad.Events;

namespace Usuarios.Domain.Commands.Seguridad.Handlers
{
    public partial class SeguridadCommandHandler : IRequestHandler<SeguridadCrearCommand, CommandResponse>
    {
        public async Task<CommandResponse> Handle(SeguridadCrearCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.CommandResponse;

            var seguridad = new Entities.Seguridad(
                Guid.NewGuid(), 
                message.IdUsuario, 
                message.Contrasena, 
                0, 
                DateTime.Now
            );

            var existeSeguridad = await _seguridadRepository.BuscaPorId(message.Id);

            if (existeSeguridad != null)
            {
                AddError($"Ya existe seguridad para el usuario con el campo 'Id' '{message.IdUsuario}'. Operación Cancelada");
                return CommandResponse;
            }

            seguridad.Intentos = 0; 
            seguridad.FechaCreacion = DateTime.Now;

            seguridad.AddDomainEvent(new SeguridadCrearEvent(
                seguridad.Id, 
                seguridad.IdUsuario, 
                seguridad.Contrasena, 
                seguridad.Intentos, 
                seguridad.FechaCreacion
            ));

            _seguridadRepository.Crear(seguridad);

            CommandResponse.Data = seguridad;
            CommandResponse.Result = true;

            return await Commit(_seguridadRepository.UnitOfWork);
        }
    }
}
