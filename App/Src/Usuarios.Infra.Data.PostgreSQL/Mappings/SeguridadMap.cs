using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Usuarios.Domain.Entities;

namespace Usuarios.Infra.Data.PostgreSQL.Mappings
{
    public class SeguridadMap : IEntityTypeConfiguration<Seguridad>
    {
        public void Configure(EntityTypeBuilder<Seguridad> builder)
        {
            builder.Property(c => c.Id).HasColumnName("Id").HasColumnType("UUID").IsRequired();
            builder.Property(c => c.IdUsuario).HasColumnName("IdUsuario").HasColumnType("UUID").IsRequired();
            builder.Property(c => c.Contrasena).HasColumnName("Contrasena").HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(c => c.Intentos).HasColumnName("Intentos").HasColumnType("int").IsRequired();
            builder.Property(c => c.FechaCreacion).HasColumnName("FechaCreacion").HasColumnType("TimeStamp").IsRequired();
        }
    }
}
