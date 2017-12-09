using System;
using System.Collections.Generic;
using Data.Core.Domain;

namespace Data.Core.Interfaces
{
    public interface ICereriRepository
    {
        IReadOnlyList<Cerere> GetAllCereriByNumarMatricol();
        Cerere GetCerereById(Guid id);
        void AddCerere(Cerere cerere);
    }
}
