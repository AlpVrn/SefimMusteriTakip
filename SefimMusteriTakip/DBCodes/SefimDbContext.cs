using Microsoft.EntityFrameworkCore;

namespace SefimMusteriTakip.DBCodes
{
    public class SefimDbContext : DbContext
    {
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<VerilenDestek> VerilenDestekler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Server=ALP\ALP;Database=SefimMusteriTakip;User Id=sa;Password=vega1234;Encrypt=false;TrustServerCertificate=true;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}