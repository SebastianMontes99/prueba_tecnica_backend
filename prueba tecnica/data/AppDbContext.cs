using Microsoft.EntityFrameworkCore;
using prueba_tecnica.models;

namespace prueba_tecnica.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Empresa> tbl_empresa { get; set; }
    }
}
