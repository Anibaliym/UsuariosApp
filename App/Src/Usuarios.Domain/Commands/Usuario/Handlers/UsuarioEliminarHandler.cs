using MediatR;
using Usuarios.Domain.Commands.Usuario.Commands;
using Usuarios.Domain.Core.Messaging;
using Usuarios.Domain.Events.Usuario.Events;

namespace Usuarios.Domain.Commands.Usuario.Handlers
{
    public partial class UsuarioCommandHandler : IRequestHandler<UsuarioEliminarCommand, CommandResponse>
    {
        public async Task<CommandResponse> Handle(UsuarioEliminarCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.CommandResponse;

            var existeUsuario = await _usuarioRepository.BuscaPorId(message.Id);

            if (existeUsuario == null)
            {
                AddError($"No existe el usuario con el id '{message.Id}'. Operación cancelada.");
                return CommandResponse;
            }

            existeUsuario.AddDomainEvent(new UsuarioEliminarEvent(existeUsuario.Id));

            _usuarioRepository.Eliminar(existeUsuario);

            CommandResponse.Data = null;
            CommandResponse.Result = true;

            return await Commit(_usuarioRepository.UnitOfWork);
        }
    }
}
