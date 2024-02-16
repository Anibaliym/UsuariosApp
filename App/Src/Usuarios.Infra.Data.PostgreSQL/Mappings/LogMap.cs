using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Usuarios.Domain.Entities;

namespace Usuarios.Infra.Data.PostgreSQL.Mappings
{
    public class LogMap : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.Property(item => item.Id).HasColumnName("Id").HasColumnType("UUID").IsRequired();
            builder.Property(item => item.IdUsuario).HasColumnName("IdUsuario").HasColumnType("UUID").IsRequired();
            builder.Property(item => item.Accion).HasColumnName("Accion").HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(item => item.Observacion).HasColumnName("Observacion").HasColumnType("varchar").IsRequired();
            builder.Property(item => item.FechaCreacion).HasColumnName("FechaCreacion").HasColumnType("TimeStamp").IsRequired();
        }
    }
}
