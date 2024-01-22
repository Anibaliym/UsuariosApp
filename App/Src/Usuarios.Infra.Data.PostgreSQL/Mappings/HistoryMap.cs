using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Usuarios.Domain.Core.Events;

namespace Usuarios.Infra.Data.PostgreSQL.Mappings
{
    public class HistoryMap : IEntityTypeConfiguration<History>
    {
        public void Configure(EntityTypeBuilder<History> builder)
        {
            builder.Property(c => c.Timestamp)
                .HasColumnName("Date");

            builder.Property(c => c.MessageType)
                .HasColumnName("Action")
                .HasColumnType("varchar(100)");
        }
    }
}
