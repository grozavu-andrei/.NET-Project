using Data.Core.Interfaces;
using Data.Persistence;

namespace Business
{
    public class CereriRepository
    {
        private readonly CereriDatabaseService _context;

        public CereriRepository(CereriDatabaseService context)
        {
            _context = context;
        }
    }
}
