using FluentValidation;
using Usuarios.Domain.Commands.CommonValidators.Validators;
using Usuarios.Domain.Enumerations.Log;
using Usuarios.Domain.Enumerations.Usuario;

namespace Usuarios.Domain.Commands.Log
{
    public abstract class LogValidation<T> : AbstractValidator<T> where T : LogCommand
    {
        protected void ValidaId()
        {
            RuleFor(item => item.Id)
                .NotEqual(Guid.Empty).WithMessage("El campo 'Id' es invalido")
                .NotEmpty().WithMessage("El campo 'Id' no puede ser vacío.");
        }

        protected void ValidaIdUsuario()
        {
            RuleFor(item => item.IdUsuario)
                .NotEqual(Guid.Empty).WithMessage("El campo 'IdUsuario' es invalido")
                .NotEmpty().WithMessage("El campo 'IdUsuario' no puede ser vacío.");
        }

        protected void ValidaAccion()
        {
            RuleFor(item => item.Accion)
                .NotEmpty().WithMessage("Por favor asegurese que el 'Accion' no este vacio")
                .Must(CommonValidator.ValidadorDeEnumeraciones<AccionEnum>).WithMessage("El tipo de dato 'Accion' debe estar entre los valores permitidos");
        }

        protected void ValidaObservacion()
        {
            RuleFor(item => item.Observacion).NotEmpty().WithMessage("Por favor asegurese que el 'Observacion' no este vacio");
        }

        protected void ValidaFechaCreacion()
        {
            RuleFor(item => item.FechaCreacion).NotEmpty().WithMessage("Por favor asegurese que el campo 'FechaCreacion' no este vacio");
        }
    }
}
