using Ardalis.SmartEnum;

namespace Usuarios.Domain.Enumerations.Usuario
{
    public sealed class TipoEnum : SmartEnum<TipoEnum>
    {
        public static readonly TipoEnum USUARIO = new("USUARIO", 1);
        public static readonly TipoEnum ADMINISTRADOR = new("ADMINISTRADOR", 2);

        private TipoEnum(string name, int value) : base(name, value) { }
    }
}
