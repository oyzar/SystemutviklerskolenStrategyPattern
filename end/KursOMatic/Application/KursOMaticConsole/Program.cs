using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Domain;
using Domain.Interfaces;
using Factory;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace ConsoleApplication1
{
    class Program
    {
        private static IKursFactory _kursFactory;
        private static UnityContainer _unityContainer;
        private const string AppName = "Kurs-o-matic v.12.00";

        static void Main(string[] args)
        {
            Console.Title = AppName;
            Console.WriteLine("######## " + AppName + " ########");

            UnityBootstrap();

            //_kursFactory = new KursFactory(new KursRepositorySql()); //TODO: Oppgave 1 b)
            _kursFactory = _unityContainer.Resolve<IKursFactory>();
            
            VerifiserOnlineDatabase();

            // Testdata: Opprett kursdeltakere
            var deltaker1 = new KursDeltaker
            {
                Person = new Person
                {
                    Adresse = "Pilestredet Park 11A",
                    Navn = "Henrik Walker Moe",
                    Mobil = "40220697"
                },
                Avdeling = "Microsoft 1"
            };

            var deltaker2 = new KursDeltaker
            {
                Person = new Person
                {
                    Adresse = "Fagerborgveien 32",
                    Navn = "Per Mathias Høgmo",
                    Mobil = "3322454"
                },
                Avdeling = "Java 2"
            };

            // Testdata: Opprett et kurs
            var kurs    = new Kurs("SW-Arkitekturkurs", 
                                   124.42, 
                                   new List<KursDeltaker>{ deltaker1, deltaker2 });
            var kursId  = _kursFactory.Opprett(kurs);
            kurs.Id     = kursId;
            Console.WriteLine("\nKurs opprettet: " + kurs);
            
            VisAlleKurs();

            VisKursInntekt();

            // Test sletting av et kurs
            Console.WriteLine("\n- Sletter kurs med Id: " + kurs.Id);
            _kursFactory.Slett(kurs.Id);
            Console.WriteLine("- Kurs slettet.");

            VisAlleKurs();

            VisKursInntekt();

            Console.ReadLine();
        }

        private static void UnityBootstrap()
        {
            _unityContainer = new UnityContainer();
            _unityContainer.AddNewExtension<Interception>();

            _unityContainer.RegisterType<IKursFactory, KursFactory>(
                new ContainerControlledLifetimeManager(),
                new Interceptor<InterfaceInterceptor>(),
                new InterceptionBehavior<LoggingInterceptionBehavior>());

            _unityContainer.RegisterType<IKursRepository, KursRepositoryFake>(
                new ContainerControlledLifetimeManager(),
                new Interceptor<InterfaceInterceptor>(),
                new InterceptionBehavior<LoggingInterceptionBehavior>());
        }

        private static void VerifiserOnlineDatabase()
        {
            if (!_kursFactory.ErDbOnline())
            {
                throw new Exception("Databasen er nede.");
            }
        }

        private static void VisKursInntekt()
        {
            var kursInntekt = _kursFactory.BeregnKursInntekt();
            
            Console.WriteLine("\n# Kursinnekter #");
            Console.WriteLine("Total kursinntekt: " + kursInntekt);
            Console.ReadLine();
        }

        private static void VisAlleKurs()
        {
            Console.WriteLine("\n# Kursoversikt #");

            var alleKurs = _kursFactory.Hent();

            if (!alleKurs.Any())
                Console.WriteLine("Ingen kurs i systemet.");

            foreach (var kurs in alleKurs)
            {
                Console.WriteLine(kurs);
            }

            Console.ReadLine();
        }
    }
}
