using Usuarios.Domain.Core.Messaging;
using Usuarios.Domain.Commands.Seguridad.Validations;

namespace Usuarios.Domain.Commands.Seguridad.Commands
{
    public class SeguridadCrearCommand : SeguridadCommand
    {
        public SeguridadCrearCommand(Guid idUsuario, string contrasena)
        {
            IdUsuario = idUsuario;
            Contrasena = contrasena;
        }

        public override bool IsValid()
        {
            CommandResponse.ValidationResult = new SeguridadCrearCommandValidations().Validate(this);
            return CommandResponse.ValidationResult.IsValid;
        }
    }
}
