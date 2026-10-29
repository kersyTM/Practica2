using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Abstracciones.Agente;

namespace DA.Agente
{
    public class AgenteConfiguracion : IEntityTypeConfiguration<Agente>
    {
        public void Configure(EntityTypeBuilder<Agente> b)
        {
            b.ToTable("Agentes");
            b.HasKey(a => a.Id);

            // Sin esto EF crea nvarchar(max) para todo: lento, sin índice posible
            // y sin protección. Los límites de aquí deben coincidir con las anotaciones de los DTOs.
            b.Property(a => a.Nombre).IsRequired().HasMaxLength(100);
            b.Property(a => a.Correo).IsRequired().HasMaxLength(150);
            b.Property(a => a.Telefono).IsRequired().HasMaxLength(20);
            b.Property(a => a.CapMaximaTicket).HasMaxLength(50);
            b.Property(a => a.FechaRegistro).HasDefaultValueSql("SYSUTCDATETIME()");
            b.Property(a => a.Estado).IsRequired().HasDefaultValue(true);

        }
    }
}