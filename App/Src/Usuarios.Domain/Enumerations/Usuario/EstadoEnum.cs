using Ardalis.SmartEnum;

namespace Usuarios.Domain.Enumerations.Usuario
{
    public sealed class EstadoEnum : SmartEnum<EstadoEnum>
    {
        public static readonly EstadoEnum ACTIVO = new("ACTIVO", 1);
        public static readonly EstadoEnum INACTIVO = new("INACTIVO", 2);
        public static readonly EstadoEnum BLOQUEADO = new("BLOQUEADO", 3);

        private EstadoEnum(string name, int value) : base(name, value) { }
    }
}
