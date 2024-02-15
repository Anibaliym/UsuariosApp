using Usuarios.Domain.Core.Messaging;
using Usuarios.Domain.Interfaces;

namespace Usuarios.Domain.Commands.Seguridad.Handlers
{
    public partial class SeguridadCommandHandler : CommandHandler
    {
        private readonly ISeguridadRepository _seguridadRepository;

        public SeguridadCommandHandler(ISeguridadRepository seguridadRepository)
        {
            _seguridadRepository = seguridadRepository ?? throw new ArgumentNullException(nameof(seguridadRepository));
        }
    }

}
