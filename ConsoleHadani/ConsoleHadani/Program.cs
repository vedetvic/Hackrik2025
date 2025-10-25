//Hra hadani cisel
//verze s rozhranim pro zobrazeni a vstup
//zatim zobrazujeme na konzoli

using ConsoleHadani;                //importuje jmeno prostoru ConsoleHadani, aby mohl pouzit tridy v nem definovane

IZobrazovac zobrazovac = new ConsoleZobrazovac(); //vytvori novy objekt tridy ConsoleZobrazovac, ktery implementuje rozhrani IZobrazovac
                                                  //tento objekt bude pouzit pro zobrazeni a nacteni vstupu
                                                  //zatim se jedna o konzolovou verzi
                                                  //diky rozhrani muzeme v budoucnu snadno zmenit implementaci zobrazovace (napr. na GUI apod.)
                                                  //bez nutnosti menit kod hry samotne
                                                  //to je vyhoda pouziti rozhrani
                                                  //ConsoleZobrazovac je konkretni implementace rozhrani IZobrazovac pro konzoli
                                                  //mohli bychom mit i jine implementace pro ruzne prostredi
                                                  //zmenu pak udelame pouze zde, bez zmeny jinde v kodu

//objekty Vstup jiz nepotrebujeme, mame zobrazovac; proto zmizely z kodu


do
{

    HraHadani mojeHra = new HraHadani(zobrazovac, zobrazovac.NactiCislo("Zadejte dolni hranici rozsahu cisel:"), zobrazovac.NactiCislo("Zadejte horni hranici rozsahu cisel:")); //vytvori novy objekt tridy HraHadani
                                                                                                                                                                                 //s nastavením hranic rozsahu cisel
                                                                                                                                                                                 //a s objektem zobrazovac pro zobrazeni a vstup
    mojeHra.Hraj();                                 //spusti hru
} while (zobrazovac.NactiText("Chcete hrat znovu? (a = ano, jinak ne)").ToLower() == "a"); //pokud uzivatel zada 'a', hra se spusti znovu

zobrazovac.ZobrazText("Dekuji za hru! Stisknete klavesu pro ukonceni."); //vypise dekovnou zpravu pri ukonceni

Console.ReadKey(); //pocka na stisk klavesy pred ukoncenim programu




