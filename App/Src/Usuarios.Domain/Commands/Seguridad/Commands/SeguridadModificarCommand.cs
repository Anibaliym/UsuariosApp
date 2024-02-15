using Usuarios.Domain.Core.Messaging;
using Usuarios.Domain.Commands.Seguridad.Validations;

namespace Usuarios.Domain.Commands.Seguridad.Commands
{
    public class SeguridadModificarCommand : SeguridadCommand
    {
        public SeguridadModificarCommand(Guid id, Guid idUsuario, string contrasena, int intentos)
        {
            Id = id;
            IdUsuario = idUsuario;
            Contrasena = contrasena;
            Intentos = intentos;
        }

        public override bool IsValid()
        {
            CommandResponse.ValidationResult = new SeguridadModificarCommandValidations().Validate(this);
            return CommandResponse.ValidationResult.IsValid;
        }
    }
}
