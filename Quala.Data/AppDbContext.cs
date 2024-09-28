using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Quala.Core.Models;
using Quala.Data.Configuration;


namespace Quala.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<NuevaEntidad> NuevaEntidades { get; set; }
        public DbSet<NuevaMoneda> NuevaMonedas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("mms");
            modelBuilder.ApplyConfiguration(new NuevaEntidadConfiguration());
            modelBuilder.ApplyConfiguration(new NuevaMonedaConfiguration());
        }
    }
}
