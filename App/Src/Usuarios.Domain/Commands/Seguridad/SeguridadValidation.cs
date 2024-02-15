using FluentValidation;

namespace Usuarios.Domain.Commands.Seguridad
{
    public abstract class SeguridadValidation<T> : AbstractValidator<T> where T : SeguridadCommand
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

        protected void ValidaContrasena()
        {
            RuleFor(item => item.Contrasena).NotEmpty().WithMessage("El campo 'Contrasena' no puede ser vacío.");
        }

        protected void ValidaIntentos()
        {
            RuleFor(item => item.Intentos).NotEmpty().WithMessage("Por favor asegurese que el campo 'Intentos' no este vacio"); 
        }

        protected void ValidaFechaCreacion()
        {
            RuleFor(item => item.FechaCreacion).NotEmpty().WithMessage("Por favor asegurese que el 'FechaCreacion' no este vacio"); 
        }
    }
}
