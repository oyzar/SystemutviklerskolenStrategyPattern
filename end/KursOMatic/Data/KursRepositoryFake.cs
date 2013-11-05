using System;
using System.Collections.Generic;
using Domain;
using Domain.Interfaces;

namespace Data
{
    public class KursRepositoryFake : IKursRepository // TODO: Oppgave 2 a) Implementér IKursRepository
    {
        private readonly List<Kurs> _kurs = new List<Kurs>(); 

        public List<Kurs> HentAlle()
        {
            return _kurs;
        }

        public Kurs Hent(int kursId)
        {
            return _kurs.Find(o => o.Id == kursId);
        }

        public int Opprett(Kurs kurs)
        {
            var kursId = HentKursId();

            kurs.Id = kursId;

            _kurs.Add(kurs);

            return kursId;
        }

        public bool Slett(int kursId)
        {
            var kurs = _kurs.Find(o => o.Id == kursId);
            _kurs.Remove(kurs);

            return true;
        }

        public bool ErOnline()
        {
            return true;
        }

        private static int HentKursId()
        {
            var random = new Random();
            var kursId = random.Next(1, 10000);

            return kursId;
        }
    }
}