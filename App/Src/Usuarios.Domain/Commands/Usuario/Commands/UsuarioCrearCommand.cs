using Usuarios.Domain.Commands.Usuario.Validations;
using Usuarios.Domain.Core.Messaging;

namespace Usuarios.Domain.Commands.Usuario.Commands
{
    public class UsuarioCrearCommand : UsuarioCommand
    {
        public UsuarioCrearCommand(Guid idPersona, string nick, string tipo, string estado)
        {
            IdPersona = idPersona;
            Nick = nick;
            Tipo = tipo;
            Estado = estado;
        }

        public override bool IsValid()
        {
            CommandResponse.ValidationResult = new UsuarioCrearCommandValidations().Validate(this);
            return CommandResponse.ValidationResult.IsValid;
        }
    }
}
