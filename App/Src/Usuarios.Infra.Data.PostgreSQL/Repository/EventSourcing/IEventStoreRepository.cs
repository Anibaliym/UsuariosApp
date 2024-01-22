using Usuarios.Domain.Core.Events;

namespace Usuarios.Infra.Data.PostgreSQL.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(History theEvent);
        Task<IList<History>> All(Guid aggregateId);
    }
}
