using MediatR;
using Usuarios.Domain.Commands.Seguridad.Commands;
using Usuarios.Domain.Core.Messaging;
using Usuarios.Domain.Events.Seguridad.Events;

namespace Usuarios.Domain.Commands.Seguridad.Handlers
{
    public partial class SeguridadCommandHandler : IRequestHandler<SeguridadModificarCommand, CommandResponse>
    {
        public async Task<CommandResponse> Handle(SeguridadModificarCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.CommandResponse;

            var seguridad = new Entities.Seguridad(message.Id, message.IdUsuario, message.Contrasena, message.Intentos, message.FechaCreacion);

            var existeSeguridad = await _seguridadRepository.BuscaPorId(message.Id);

            if (existeSeguridad == null)
            {
                AddError($"No existe la seguirdad con el id '{message.Id}'.");
                return CommandResponse;
            }

            seguridad.FechaCreacion = existeSeguridad.FechaCreacion; 

            seguridad.AddDomainEvent(new SeguridadModificarEvent(seguridad.Id, seguridad.IdUsuario, seguridad.Contrasena, seguridad.Intentos, seguridad.FechaCreacion));

            _seguridadRepository.Modificar(seguridad);

            CommandResponse.Data = seguridad;
            CommandResponse.Result = true;

            return await Commit(_seguridadRepository.UnitOfWork);
        }
    }
}
