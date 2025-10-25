//Hra hadani cisel
//verze s rozhranim pro zobrazeni a vstup
//pridano jednoduche TUI pro konzolove zobrazeni

using ConsoleHadani;



IZobrazovac zobrazovac = new TuiZobrazovac();           //vytvori novy objekt tridy TuiZobrazovac, ktery implementuje rozhrani IZobrazovac
                                                        //tento objekt bude pouzit pro zobrazeni a nacteni vstupu
                                                        //je to jedina zmena v programu oproti puvodni verzi
                                                        //na tridu HraHadani jsme nijak nesahali

//IZobrazovac zobrazovac = new ConsoleZobrazovac(); puvodni konzolove zobrazeni ted je nahradeno TUI


do
{

    HraHadani mojeHra = new HraHadani(zobrazovac, zobrazovac.NactiCislo("Zadejte dolni hranici rozsahu cisel:"), zobrazovac.NactiCislo("Zadejte horni hranici rozsahu cisel:")); //vytvori novy objekt tridy HraHadani
                                                                                                                                                                                 //s nastavením hranic rozsahu cisel
                                                                                                                                                                                 //a s objektem zobrazovac pro zobrazeni a vstup
    mojeHra.Hraj();                                 //spusti hru
} while (zobrazovac.NactiText("Chcete hrat znovu? (a = ano, jinak ne)").ToLower() == "a"); //pokud uzivatel zada 'a', hra se spusti znovu

zobrazovac.ZobrazText("Dekuji za hru!"); //vypise dekovnou zpravu pri ukonceni
                                         //tim koncime, necekame na klavesu jako v puvodni verzi
                                         //to za nas resi TUI rozhrani





