using Data.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistence
{
    public interface ICereriDatabaseService
    {
        DbSet<Cerere> Cereri { get; set; }
        int SaveChanges();
    }
}
