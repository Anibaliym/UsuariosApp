using Usuarios.Domain.Commands.Log.Commands;

namespace Usuarios.Domain.Commands.Log.Validations
{
    public class LogCrearCommandValidations : LogValidation<LogCrearCommand>
    {
        public LogCrearCommandValidations()
        {
            ValidaIdUsuario();
            ValidaAccion();
        }
    }
}
