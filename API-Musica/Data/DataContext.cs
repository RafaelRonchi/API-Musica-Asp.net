using API_Musica.Model;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace API_Musica.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Musica> Musicas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=DESKTOP-H7EP5Q1\\SQLEXPRESS;database=musicasdb;trusted_connection=true; TrustServerCertificate=True");
        }
    }
}
