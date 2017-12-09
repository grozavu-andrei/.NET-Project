using Microsoft.EntityFrameworkCore;

namespace Data.Persistence
{
    public class CereriDatabaseService : DbContext
    {
        public CereriDatabaseService(DbContextOptions<CereriDatabaseService> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Data.Core.Domain.Cerere> Cereri { get; set; }
    }
}
