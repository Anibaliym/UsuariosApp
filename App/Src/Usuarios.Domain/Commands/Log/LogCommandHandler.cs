using Usuarios.Domain.Core.Messaging;
using Usuarios.Domain.Interfaces;

namespace Usuarios.Domain.Commands.Log.Handlers
{
    public partial class LogCommandHandler : CommandHandler
    {
        private readonly ILogRepository _logRepository;

        public LogCommandHandler(ILogRepository logRepository)
        {
            _logRepository = logRepository ?? throw new ArgumentNullException(nameof(logRepository));
        }
    }
}
