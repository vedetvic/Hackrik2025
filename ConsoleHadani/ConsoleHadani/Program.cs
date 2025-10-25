//Hra hadani cisel - prvni objektova verze

using ConsoleHadani;                //importuje jmeno prostoru ConsoleHadani, aby mohl pouzit tridy v nem definovane

Vstup jesteJednou = new Vstup("Chcete hrat znovu? (a = ano, jinak ne)"); //vytvori novy objekt tridy Vstup s vyzvou pro uzivatele
Vstup vstDolniHranice = new Vstup("Zadejte dolni hranici rozsahu cisel: "); //vytvori novy objekt tridy Vstup pro dolni hranici
Vstup vstHorniHranice = new Vstup("Zadejte horni hranici rozsahu cisel: "); //vytvori novy objekt tridy Vstup pro horni hranici


do
{

    HraHadani mojeHra = new HraHadani(vstDolniHranice.NactiCislo(), vstHorniHranice.NactiCislo()); //vytvori novy objekt tridy HraHadani
                                                                                                   //s nastavením hranic rozsahu cisel
    mojeHra.Hraj();                                 //spusti hru
} while (jesteJednou.NactiText().ToLower() == "a"); //pokud uzivatel zada 'a', hra se spusti znovu

Console.WriteLine("Dekuji za hru! Stisknete klavesu pro ukonceni."); //vypise dekovnou zpravu pri ukonceni
Console.ReadKey(); //pocka na stisk klavesy pred ukoncenim programu




