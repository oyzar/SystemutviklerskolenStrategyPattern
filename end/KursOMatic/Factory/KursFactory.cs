using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Interfaces;

namespace Factory
{
    public class KursFactory : IKursFactory
    {
        private readonly IKursRepository _kursRepository;

        public KursFactory(IKursRepository kursRepository)
        {
            _kursRepository = kursRepository;
        }

        public int Opprett(Kurs kurs)
        {
            return _kursRepository.Opprett(kurs);
        }

        public bool Slett(int kursId)
        {
            return _kursRepository.Slett(kursId);
        }

        public List<Kurs> Hent()
        {
            return _kursRepository.HentAlle();
        }

        public Kurs Hent(int kursId)
        {
            return _kursRepository.Hent(kursId);
        }

        public double BeregnKursInntekt()
        {
            var alleKurs = _kursRepository.HentAlle();

            return (from kurs in alleKurs 
                    let deltakere = kurs.HentAntallDeltakere() 
                    select deltakere * kurs.Pris).Sum();
        }

        public bool ErDbOnline()
        {
            return _kursRepository.ErOnline();
        }
    }
}
