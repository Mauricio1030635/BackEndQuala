using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Quala.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quala.Data.Configuration
{
    public class NuevaMonedaConfiguration : IEntityTypeConfiguration<NuevaMoneda>
    {
        public void Configure(EntityTypeBuilder<NuevaMoneda> builder)
        {
            builder.ToTable("NuevaMoneda"); 

            builder.HasKey(m => m.IdMoneda);

            builder.Property(m => m.CodigoMoneda)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(m => m.NombreMoneda)
                .IsRequired()
                .HasMaxLength(100);

            // Datos semilla
            builder.HasData(
                new NuevaMoneda { IdMoneda = 1, CodigoMoneda = "USD", NombreMoneda = "Dólar Americano" },
                new NuevaMoneda { IdMoneda = 2, CodigoMoneda = "GBP", NombreMoneda = "Libra Esterlina" }
            );
        }
    }
}
