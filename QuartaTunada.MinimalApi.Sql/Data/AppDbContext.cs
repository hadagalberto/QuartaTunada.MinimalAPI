using Microsoft.EntityFrameworkCore;
using QuartaTunada.MinimalApi.Sql.Models;

namespace QuartaTunada.MinimalApi.Sql.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Carro> Carros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("QuataTunada");
        }

    }
}
