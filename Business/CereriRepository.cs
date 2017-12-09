using System;
using System.Collections.Generic;
using System.Linq;
using Data.Core.Domain;
using Data.Core.Interfaces;
using Data.Persistence;

namespace Business
{
    public class CereriRepository : ICereriRepository
    {
        private readonly CereriDatabaseService _context;

        public CereriRepository(CereriDatabaseService context)
        {
            _context = context;
        }

        public IEnumerable<Cerere> GetAllCereriByNumarMatricol(string nrMatricol)
        {
            return _context.Cereri.Where(t => t.NumarMatricol == nrMatricol);
        }

        public Cerere GetCerereById(Guid id)
        {
            return _context.Cereri.FirstOrDefault(t => t.Id == id);
        }

        public void AddCerere(Cerere cerere)
        {
            _context.Cereri.Add(cerere);
            _context.SaveChanges();
        }

        public void SchimbaStareCerere(Guid id, string stare)
        {
            var cerere = GetCerereById(id);
            cerere.SchimbaStare(stare);
            _context.SaveChanges();
        }
    }
}
