Systemutviklerskolen - Design Patterns workshopoppgaver C#

Oppsett
	• Ha installert Visual Studio 2012
	• Ha installert NuGet-extension
	
Ressurser
	• Visual studio prosjekt: <path>
	• A developer's guide to Dependency Injection using Unity 3 - http://msdn.microsoft.com/en-us/library/dn170416.aspx
	
Case
	Du er en del av et team som skal lage et kurshåndteringssystem som en Windows Console Application. Dere har gått for en lagdelt struktur med Application (front-end), Business (forretningslogikk), Domain (domeneentiteter) og Data (dataaksess) som lag. Du har ansvaret for Application-, Business og Domain-lagene mens din kollega, Ola, har ansvaret for Data-laget. Dataaksess er planlagt å skje via en database men dere har ikke helt klart for dere noe db-skjema ennå. 
	
	Dere har vært igjennom en tøff dag i går hvor deler av løsningen ble raskt prototypet til en kundedemo på neste fredag.
	
	Oppgave 1
	
		Det er dag 2 i prosjektet og prototypingen dere har gjort i går kveld skal omskrives til å implementere IoC med Dependency Injection (DI).
	
		a. Installer Unity via NuGet (pakkenavn: "Unity")
		b. Konfigurer Unity til å resolve IKursFactory til KursFactory
			i. Hint:
				1) var unityContainer = new UnityContainer();
				2) unityContainer.RegisterType<(IClassContract), (ConcreteType)>();
				3) var minKlasseInstans = unityContainer.Resolve<IClassContract>();
		
	Oppgave 2
	
		Det er dagen før demo. Datahenting foregår ved bruk av "repositories" i Data-laget. Alle "repositories" implementerer et interface som er kontrakten for operasjoner mot en datakilde. Kontrakten for kursrepository er IKursRepository.
		
		Ola på teamet som er ansvarlig for databaseinteraksjon skal lage en klasse for henting av kurs kalt KursRepositorySql, men det ser ikke ut som om han rekker demofristen i morgen og du kommer ikke videre med utviklingen. På demoen må det vises en fungerende prototype av systemet, med data! 
		
		a. Implementer KursRespositoryFake slik at dere får vist data i applikasjonen.
			i. Hint:
				1) Bruk "private List<Kurs>" slik at du kan fake en databasetabell for kursene.
		b. Bruk DI og Unity til å sette opp IKursRepository til å resolve til KursRepositoryFake. Repositoryklassen som blir resolvet av Unity skal bli brukt som en "Singleton" av applikasjonen.
			i. Hint: Lær mer om Lifetime Managers her: http://msdn.microsoft.com/en-us/library/ff647854.aspx
			
			
	Oppgave 3
	
		Dere begynne å få kontroll til demoen men føler at dere savner å forstå hva som skjer til hvilken tid i applikasjonen, og i hvilken rekkefølge ting skjer. Derfor ønsker dere å implementere Trace-logging i metodekall. Dette finner dere ut kan gjøres ved hjelp av Interceptors i Unity. 
		
		a. Implementer LoggingInterceptionBehavior-klassen på alle typene som er registrert i Unity-containeren
			i. Hint:
				1) NuGet-pakkenavn: "Unity.Interception"
			ii. Trace-output i Debug-vinduet i Visual Studio skal være på formatet: 
				? Kaller metode <returtype> <metodenavn> - kl. <tid>
				og
				? Metode <returtype> <metodenavn> returnerte <returverdi> - kl. <tid>
