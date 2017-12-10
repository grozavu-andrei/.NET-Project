using System;

namespace Data.Core.Domain
{
    public class Cerere
    {
        public Guid Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string InitialaTatalui { get; set; }
        public string Email { get; set; }
        public string NumarMatricol { get; set; }
        public string SerieBuletin { get; set; }
        public int NumarBuletin { get; set; }
        public string StareCerere { get; private set; }


        public Cerere()
        {
            Id = new Guid();
            StareCerere = "In asteptare";
        }

        public void SchimbaStare(string stare)
        {
            StareCerere = stare;
        }
    }
}
