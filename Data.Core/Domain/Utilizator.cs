using System;

namespace Data.Core.Domain
{
    public class Utilizator
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Parola { get; set; }
        public string Tip { get; set; }

        public Utilizator()
        {
            Id = new Guid();
        }
    }
}
