using Ardalis.SmartEnum;

namespace Usuarios.Domain.Enumerations.Log
{
    public sealed class AccionEnum : SmartEnum<AccionEnum>
    {
        public static readonly AccionEnum USUARIO_CREADO_CON_SEGURIDAD = new ("USUARIO_CREADO_CON_SEGURIDAD", 1);
        public static readonly AccionEnum USUARIO_CREADO_SIN_SEGURIDAD = new ("USUARIO_CREADO_SIN_SEGURIDAD", 2);
        public static readonly AccionEnum INTENTO_FALLIDO = new ("INTENTO_FALLIDO", 3);
        public static readonly AccionEnum USUARIO_BLOQUEADO = new ("USUARIO_BLOQUEADO", 4);

        private AccionEnum(string name, int value) : base(name, value) { }
    }
}
