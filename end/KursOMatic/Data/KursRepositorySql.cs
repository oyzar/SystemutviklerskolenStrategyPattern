using System;
using System.Collections.Generic;
using Domain;
using Domain.Interfaces;

namespace Data
{
    public class KursRepositorySql : IKursRepository
    {
        public List<Kurs> HentAlle()
        {
            throw new NotImplementedException(); //TODO Ola: Jeg jobber med saken!
        }

        public Kurs Hent(int kursId)
        {
            throw new NotImplementedException(); //TODO Ola: Jeg jobber med saken!
        }

        public int Opprett(Kurs kurs)
        {
            throw new NotImplementedException(); //TODO Ola: Jeg jobber med saken!
        }

        public bool Slett(int kursId)
        {
            throw new NotImplementedException(); //TODO Ola: Jeg jobber med saken!
        }

        public bool ErOnline()
        {
            return false;
        }
    }
}
