using Usuarios.Domain.Core.Messaging;
using Usuarios.Domain.Interfaces;

namespace Usuarios.Domain.Commands.Usuario.Handlers
{
    public partial class UsuarioCommandHandler : CommandHandler
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
        }
    }
}
