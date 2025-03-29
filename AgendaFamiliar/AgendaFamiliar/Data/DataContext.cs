using Microsoft.EntityFrameworkCore;
using AgendaFamiliar.Models;

namespace AgendaFamiliar.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Agendar> Agendar {  get; set; }

    }
}
