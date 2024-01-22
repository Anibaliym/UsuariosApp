using Usuarios.Domain.Core.Messaging;

namespace Usuarios.Domain.Core.Events
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}
