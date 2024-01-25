using MediatR;
using Usuarios.Domain.Commands.Usuario.Commands;
using Usuarios.Domain.Core.Messaging;
using Usuarios.Domain.Events.Usuario.Events;

namespace Usuarios.Domain.Commands.Usuario.Handlers
{
    public partial class UsuarioCommandHandler : IRequestHandler<UsuarioCrearCommand, CommandResponse>
    {
        public async Task<CommandResponse> Handle(UsuarioCrearCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.CommandResponse;

            var usuario = new Entities.Usuario(
                Guid.NewGuid(), 
                message.IdPersona, 
                message.Nick.ToUpper(), 
                message.Tipo.ToUpper(), 
                message.Estado.ToUpper()
            );

            var existeUsuarioPorIdPersona = await _usuarioRepository.BuscaPorIdPersona(message.IdPersona);
            var existeUsuarioConNick = await _usuarioRepository.BuscaPorNick(message.Nick.ToUpper());

            if (existeUsuarioConNick != null)
            {
                AddError($"Ya existe un usuario con el campo 'NICK' '{message.Nick}'. Operación Cancelada");
                return CommandResponse;
            }

            if (existeUsuarioPorIdPersona != null)
            {
                AddError($"Ya existe un usuario con el 'IdPersona' '{message.IdPersona}'. Operación Cancelada");
                return CommandResponse;
            }

            usuario.AddDomainEvent(new UsuarioCrearEvent(
                usuario.Id,
                message.IdPersona, 
                message.Nick, 
                message.Tipo, 
                message.Estado
            ));

            _usuarioRepository.Crear(usuario);

            CommandResponse.Data = usuario;
            CommandResponse.Result = true;

            return await Commit(_usuarioRepository.UnitOfWork);
        }
    }
}
