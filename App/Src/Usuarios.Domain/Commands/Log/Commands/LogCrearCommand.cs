using Usuarios.Domain.Commands.Log.Validations;
using Usuarios.Domain.Core.Messaging;

namespace Usuarios.Domain.Commands.Log.Commands
{
    public class LogCrearCommand : LogCommand
    {
        public LogCrearCommand(Guid idUsuario, string accion, string observacion)
        {
            IdUsuario = idUsuario;
            Accion = accion;
            Observacion = observacion;
        }

        public override bool IsValid()
        {
            CommandResponse.ValidationResult = new LogCrearCommandValidations().Validate(this);
            return CommandResponse.ValidationResult.IsValid;
        }
    }
}
