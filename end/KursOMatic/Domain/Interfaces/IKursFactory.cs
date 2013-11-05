using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IKursFactory
    {
        int Opprett(Kurs kurs);
        bool Slett(int kursId);
        List<Kurs> Hent();
        Kurs Hent(int kursId);
        double BeregnKursInntekt();
        bool ErDbOnline();
    }
}