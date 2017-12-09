using System;
using System.Collections.Generic;
using Data.Core.Domain;

namespace Data.Core.Interfaces
{
    public interface ICereriRepository
    {
        IEnumerable<Cerere> GetAllCereriByNumarMatricol(string nrMatricol);
        Cerere GetCerereById(Guid id);
        void AddCerere(Cerere cerere);
        void SchimbaStareCerere(Guid id, string stare);
    }
}
