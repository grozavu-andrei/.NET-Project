using Data.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistence
{
    public class UtilizatoriDatabaseService : DbContext
    {
        public UtilizatoriDatabaseService(DbContextOptions<UtilizatoriDatabaseService> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Utilizator> Utilizatori { get; set; }
    }
}
