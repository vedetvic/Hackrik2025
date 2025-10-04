//Hra hadani cisel - prvni objektova verze

using ConsoleHadani;                //importuje jmeno prostoru ConsoleHadani, aby mohl pouzit tridy v nem definovane

Vstup jesteJednou = new Vstup("Chcete hrat znovu? (a = ano, jinak ne)"); //vytvori novy objekt tridy Vstup s vyzvou pro uzivatele

HraHadani mojeHra = new HraHadani(); //vytvori novy objekt tridy HraHadani
do
{
    mojeHra.Hraj();                 //spusti hru
} while (jesteJednou.NactiText().ToLower() == "a"); //pokud uzivatel zada 'a', hra se spusti znovu

Console.WriteLine("Dekuji za hru! Stisknete klavesu pro ukonceni."); //vypise dekovnou zpravu pri ukonceni
Console.ReadKey(); //pocka na stisk klavesy pred ukoncenim programu




