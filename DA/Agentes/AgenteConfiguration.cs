using Abstracciones.Agentes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DA.Agentes
{
    public class AgenteConfiguracion : IEntityTypeConfiguration<Agente>
    {
        public void Configure(EntityTypeBuilder<Agente> a)
        {
            a.ToTable("Agentes");
            a.HasKey(a => a.Id);

            // Sin esto EF crea nvarchar(max) para todo: lento, sin índice posible
            // y sin protección. Los límites de aquí deben coincidir con las anotaciones de los DTOs.
            a.Property(a => a.Nombre).IsRequired().HasMaxLength(100);
            a.Property(a => a.Correo).IsRequired().HasMaxLength(150);
            a.Property(a => a.Telefono).IsRequired().HasMaxLength(20);
            a.Property(a => a.CapMaximaTicket).HasMaxLength(50);
            a.Property(a => a.FechaRegistro).HasDefaultValueSql("SYSUTCDATETIME()");
            a.Property(a => a.Activo).IsRequired().HasDefaultValue(true);
            a.HasIndex(a => a.Correo).IsUnique();

        }
    }
}