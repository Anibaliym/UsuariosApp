using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Usuarios.Domain.Entities;

namespace Usuarios.Infra.Data.PostgreSQL.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(c => c.Id).HasColumnName("Id").HasColumnType("UUID").IsRequired();
            builder.Property(c => c.IdPersona).HasColumnName("IdPersona").HasColumnType("UUID").IsRequired();
            builder.Property(c => c.Nick).HasColumnName("Nick").HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(c => c.Tipo).HasColumnName("Tipo").HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(c => c.Estado).HasColumnName("Estado").HasColumnType("varchar").HasMaxLength(50).IsRequired();
        }
    }
}
