using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IKursRepository
    {
        List<Kurs> HentAlle();
        Kurs Hent(int kursId);
        int Opprett(Kurs kurs);
        bool Slett(int kursId);
        bool ErOnline();
    }
}