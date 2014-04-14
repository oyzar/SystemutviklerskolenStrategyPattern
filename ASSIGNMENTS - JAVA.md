Oppgave 1

Main klass for Java program er Program.java. Metoden public static void main(String [] args) i Program.java leser inn to parameter fra kommando-linje og parser dette til en Gender og SalesMode objekt og bruker disse med en svær nested if blokk (Arrow Anti-Pattern) som velger anbefalt produkt. Første del av oppgaven er å fjerne den svær nested 'if' blokk og velg riktig anbefalingsstrategi i runtime .

Input:

    Les inn Gender som et tekst og resolver til et enum
    Les inn SalesMode som et tekst og resolver til et enum

Output

    Navn på vare og valgt type som implementerer ProductRecommender ut til Console
        Eksempel: "<produktnavn>, Recommender: <recommenders klassenavn>"

a) Implementer innlesing av input fra konsoll til to lokal variabeler "gender" (Gender) og "salesMode" (SalesMode)

b) Opprett en ny interface interface ProductRecommender som har to metoder: "Product recommend(Customer customer)" og "boolean supports(SalesMode salesMode)"

c) Implementer Strategy-klassene GenderProductRecommender, LowPriceProductRecommender og SeasonalProductRecommender.

    Bruk et virkårlig produktnavn. Implementering av produktdatabase er utenfor scopet.

d) Instansier SalesEngine implementasjon med tilgjengelig ProductRecommender klasser

e) Implementer SalesEngine sin metod Product recommend(SalesMode salesMode, Customer customer) som bruker riktig ProductRecommender å anbefale produkt
Oppgave 2

Java utviklerne kan bruke PicoContainer som er en del av kodebase mapper dere får. Hele PicoContainer rammeverk er under 324 KB og ligger under ${project.home}/java-lib/ mappe.

a) Inkluder ${project.home}/java-lib/ mappe i kompilering og run-time library path på din IDE

b) Legge til kontainer oppstart kode i Program.java (eller hvor du synes er fornuftig):

MutablePicoContainer picoContainer = new PicoBuilder().build();

c) Opprett en ny lokal variabel "salesEngine" og bruk MutablePicoContainer til å resolve SalesEngine til typen SalesEngineImpl.

d) Bruk SalesEngine sin recommend() med SalesMode og Customer parameterne