using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quala.Core.Models;
using System;

namespace Quala.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    public class NuevaEntidadConfiguration : IEntityTypeConfiguration<NuevaEntidad>
    {
        public void Configure(EntityTypeBuilder<NuevaEntidad> builder)
        {
            builder.ToTable("NuevaEntidad");

            builder.HasKey(e => e.Codigo);

            builder.Property(e => e.Codigo)
                .IsRequired();

            builder.Property(e => e.Descripcion)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(e => e.Direccion)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(e => e.Identificacion)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.FechaCreacion)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            
            builder.HasCheckConstraint("CK_FechaCreacion", "FechaCreacion >= GETDATE()");

            builder.HasOne(e => e.NuevaMoneda)
                .WithMany(m => m.NuevaEntidades)
                .HasForeignKey(e => e.MonedaId)
                .IsRequired();

            // Datos semilla
            builder.HasData(
                new NuevaEntidad
                {
                    Codigo = 1,
                    Descripcion = "Empresa XYZ",
                    Direccion = "456 Calle Secundaria",
                    Identificacion = "987654321",
                    FechaCreacion = DateTime.Now,
                    MonedaId = 1
                }
            );
        }
    }

}
