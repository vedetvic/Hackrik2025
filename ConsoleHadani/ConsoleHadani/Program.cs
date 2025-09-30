//Hra hadani cisel

Console.Clear();   //smaze obrazovku
Console.WriteLine("Vitejte ve hre Hadani cisel!"); //vypise uvodni zpravu
Console.WriteLine("Myslim si cislo od 1 do 100. Uhodni ho na co nejmene pokusu.");
Random random = new Random(); //vytvori novy objekt pro generovani nahodnych cisel
int cislo = random.Next(1, 101);  //vygeneruje nahodne cislo mezi 1 a 100
int pokus = 0;  //pocitadlo pokusu
int tip = 0;  //uzivateluv tip
do
{                                           //zacatek smycky (cyklu) do-while
    Console.Write("Zadejte svuj tip: ");    //vyzve uzivatele k zadani tipu
    string? vstup = Console.ReadLine();     //nacte uzivateluv vstup
    try                                     //zachyti vyjimky pri prevodu vstupu na cele cislo
    {
        if (vstup == null)                  //kontrola, zda uzivatel nezadal prazdny vstup
        {
            Console.WriteLine("Neplatny vstup. Zadejte cele cislo mezi 1 a 100.");  //vypise chybovou zpravu
            continue;                       //pokračuje na začátek smyčky
        }

        tip = int.Parse(vstup);             //prevod vstupu na cele cislo

        if (tip < 1 || tip > 100)           //kontrola, zda je tip v povolenem rozsahu
        {
            Console.WriteLine("Cislo musi byt mezi 1 a 100. Zkuste to znovu."); //vypise chybovou zpravu
            continue;                       //pokračuje na začátek smyčky
        }
        pokus++;                            //pocita pokusy v pripadě platného tipu
    }
    catch                                   //zachyti vyjimky pri prevodu vstupu na cele cislo         
    {
        Console.WriteLine("Neplatny vstup. Zadejte cele cislo mezi 1 a 100."); //vypise chybovou zpravu
        continue;                           //pokračuje na začátek smyčky
    }
    if (tip < cislo)                        //porovna uzivateluv tip s generovanym cislem
    {
        Console.WriteLine("Moje cislo je vetsi. Zkuste to znovu.");  //vypise napovedu
    }
    else if (tip > cislo)                   //porovna uzivateluv tip s generovanym cislem
    {
        Console.WriteLine("Moje cislo je mensi. Zkuste to znovu.");  //vypise napovedu
    }
    else
    {
        Console.WriteLine($"Gratuluji! Uhodl jste cislo {cislo} na {pokus} pokusu.");  //vypise gratulaci pri uhodnuti

    }

} while (tip!=cislo);                       //konec smycky (cyklu) do-while, pokracuje dokud uzivatel neuhodne cislo




