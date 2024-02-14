using Microsoft.EntityFrameworkCore;
using WebApiMeteo.Entities;

namespace WebApiMeteo.Db
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Ville> Villes { get; set; }

        public DbSet<Meteo> Meteos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ville>(entity =>
            {
                entity.ToTable("Ville");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasMaxLength(500);

            });

            modelBuilder.Entity<Meteo>(entity =>
            {
                entity.ToTable("Meteo");

                entity.HasOne(e => e.Ville)
                    .WithMany(a => a.Meteos)
                    .HasForeignKey(d => d.MeteoId)
                    .HasConstraintName("FK_Meteo_VilleId_ToTable_Ville_Id");

                entity.Property(e => e.Date)
                    .IsRequired();
            });
        }
    }
}
