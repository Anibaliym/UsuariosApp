using MediatR;
using Usuarios.Domain.Commands.Usuario.Commands;
using Usuarios.Domain.Core.Messaging;
using Usuarios.Domain.Events.Usuario.Events;

namespace Usuarios.Domain.Commands.Usuario.Handlers
{
    public partial class UsuarioCommandHandler : IRequestHandler<UsuarioModificarCommand, CommandResponse>
    {
        public async Task<CommandResponse> Handle(UsuarioModificarCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.CommandResponse;

            var usuario = new Entities.Usuario(
                message.Id, 
                message.IdPersona, 
                message.Nick.ToUpper(), 
                message.Tipo.ToUpper(), 
                message.Estado.ToUpper()
            );

            var existeUsuario = await _usuarioRepository.BuscaPorId(message.Id);

            if (existeUsuario == null)
            {
                AddError($"No existe el contacto con el id '{message.Id}'.");
                return CommandResponse;
            }

            usuario.AddDomainEvent(new UsuarioModificarEvent(
                usuario.Id, 
                usuario.IdPersona, 
                usuario.Nick, 
                usuario.Tipo, 
                usuario.Estado
            ));

            _usuarioRepository.Modificar(usuario);

            CommandResponse.Data = usuario;
            CommandResponse.Result = true;

            return await Commit(_usuarioRepository.UnitOfWork);
        }
    }
}