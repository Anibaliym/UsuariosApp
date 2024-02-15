using FluentValidation;
using Usuarios.Domain.Commands.CommonValidators.Validators;
using Usuarios.Domain.Enumerations.Usuario;

namespace Usuarios.Domain.Commands.Usuario
{
    public abstract class UsuarioValidation<T> : AbstractValidator<T> where T : UsuarioCommand
    {
        protected void ValidaId()
        {
            RuleFor(item => item.Id)
                .NotEqual(Guid.Empty).WithMessage("El campo 'Id' es invalido")
                .NotEmpty().WithMessage("El campo 'Id' no puede ser vacío.");
        }

        protected void ValidaIdPersona()
        {
            RuleFor(item => item.IdPersona)
                .NotEqual(Guid.Empty).WithMessage("El campo 'IdPersona' es invalido")
                .NotEmpty().WithMessage("El campo 'IdPersona' no puede ser vacío.");
        }

        protected void ValidaNick()
        {
            RuleFor(item => item.Nick).NotEmpty().WithMessage("El campo 'Nick' no puede ser vacío.");
        }

        protected void ValidaTipo()
        {
            RuleFor(item => item.Tipo)
                .NotEmpty().WithMessage("Por favor asegurese que el 'Tipo' no este vacio")
                .Must(CommonValidator.ValidadorDeEnumeraciones<TipoEnum>).WithMessage("El 'Tipo' debe estar entre los valores permitidos ('USUARIO','ADMINISTRADOR').");
        }

        protected void ValidaEstado()
        {
            RuleFor(item => item.Estado)
                .NotEmpty().WithMessage("Por favor asegurese que el 'Estado' no este vacio")
                .Must(CommonValidator.ValidadorDeEnumeraciones<EstadoEnum>).WithMessage("El 'Estado' debe estar entre los valores permitidos ('ACTIVO','INCATIVO', 'SUSPENDIDO').");
        }
    }
}
