using Microsoft.EntityFrameworkCore;
using Usuarios.Domain.Core.Events;
using Usuarios.Infra.Data.PostgreSQL.Mappings;

namespace Usuarios.Infra.Data.PostgreSQL.Context
{
    public class EventStoreSqlContext : DbContext
    {
        public EventStoreSqlContext(DbContextOptions<EventStoreSqlContext> options) : base(options) { }

        public DbSet<History> History { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HistoryMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
