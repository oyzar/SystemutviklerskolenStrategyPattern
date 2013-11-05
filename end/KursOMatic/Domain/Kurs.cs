using System.Collections.Generic;
using Domain.Interfaces;

namespace Domain
{
    public class Kurs
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        private List<KursDeltaker> KursDeltakere { get; set; }
        public double Pris { get; set; }

        public Kurs(string navn, double pris, List<KursDeltaker> kursDeltakerere)
        {
            Navn = navn;
            Pris = pris;
            KursDeltakere = kursDeltakerere;
        }
        
        public int HentAntallDeltakere()
        {
            return KursDeltakere.Count;
        }

        public override string ToString()
        {
            return Id + ", \"" + Navn + "\", Antall deltakere: " + HentAntallDeltakere();
        }
    }
}