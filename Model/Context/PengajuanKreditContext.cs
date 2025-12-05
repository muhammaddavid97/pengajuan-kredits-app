using Microsoft.EntityFrameworkCore;

namespace SkyWorkTask.Model.Context
{
    public class PengajuanKreditContext : DbContext
    {

        public DbSet<PengajuanKredit> PengajuanKredits { get; set; }
        public PengajuanKreditContext(DbContextOptions<PengajuanKreditContext> options) : base(options) 
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PengajuanKredit>()
                .HasIndex(s => s.Plafon)
                .HasDatabaseName("idx_plafon");

            modelBuilder.Entity<PengajuanKredit>()
                .HasIndex(s => s.Tenor)
                .HasDatabaseName("idx_Tenor");
                
        }
    }
}
