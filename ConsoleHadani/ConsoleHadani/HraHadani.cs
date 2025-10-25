using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHadani
{
    /// <summary>
    /// Trida pro hru Hadani cisel
    /// </summary>
    public class HraHadani
    {
        private readonly IZobrazovac _zobrazovac; //rozhrani pro zobrazeni textu a nacteni vstupu
        public int DolniHranice { get; set; } = 1; //dolni hranice rozsahu cisel
        public int HorniHranice { get; set; } = 100; //horni hranice rozsahu cisel

        /// <summary>
        /// Konstruktor s parametry pro nastaveni hranic rozsahu cisel
        /// </summary>
        /// <param name="dolniHranice">Dolní hranice intervalu myšlených čísel</param>
        /// <param name="horniHranice">Horní hranice intervalu myšlených čísel</param>
        public HraHadani(IZobrazovac zobrazovac, int dolniHranice, int horniHranice)
        {
            DolniHranice = dolniHranice;
            HorniHranice = horniHranice;
            _zobrazovac = zobrazovac;       //nastavi zobrazovac - viz nize
        }

        public HraHadani(IZobrazovac zobrazovac) 
        {
            //pouzije vychozi hodnoty hranic
            _zobrazovac = zobrazovac;       //nastavi zobrazovac - objekt implementujici rozhrani IZobrazovac
                                            //zobrazeni a nacteni vstupu bude probihat pres tento objekt
                                            //to umoznuje flexibilitu - muzeme pouzit ruzne implementace rozhrani IZobrazovac
                                            //napr. pro konzoli, GUI, web apod.
        }

        /// <summary>
        /// Spusti a zahraje jednu hru Hadani cisel
        /// </summary>
        public void Hraj()
        {
            Console.Clear();   //smaze obrazovku
            _zobrazovac.ZobrazText("Vitejte ve hre Hadani cisel!"); //vypise uvodni zpravu
            
            _zobrazovac.ZobrazText($"Myslim si cislo od {DolniHranice} do {HorniHranice}. Uhodni ho na co nejmene pokusu."); //tzv. interpolovaný řetězec s hranicemi rozsahu
                                                                                                                        //obsahuje promenne primo v retezci
            Random random = new Random(); //vytvori novy objekt pro generovani nahodnych cisel
            
            // nepotrebujeme, mame zobrazovac // Vstup VlozeneCislo= new Vstup("Zadejte svuj tip: "); //vytvori novy objekt tridy Vstup s vyzvou pro uzivatele

            int cislo = random.Next(DolniHranice, HorniHranice+1);  //vygeneruje nahodne cislo v zadanem rozsahu
            int pokus = 0;  //pocitadlo pokusu
            int tip = 0;  //uzivateluv tip
            do
            {                                           //zacatek smycky (cyklu) do-while
                tip = _zobrazovac.NactiCislo("Zadejte svuj tip: ");        //nacte uzivateluv tip
                pokus++;                                 //zvysi pocitadlo pokusu o 1

                if (tip < cislo)                        //porovna uzivateluv tip s generovanym cislem
                {
                    _zobrazovac.ZobrazText("Moje cislo je vetsi. Zkuste to znovu.");  //vypise napovedu
                }
                else if (tip > cislo)                   //porovna uzivateluv tip s generovanym cislem
                {
                    _zobrazovac.ZobrazText("Moje cislo je mensi. Zkuste to znovu.");  //vypise napovedu
                }
                else
                {
                    _zobrazovac.ZobrazText($"Gratuluji! Uhodl jste cislo {cislo} na {pokus} pokusu.");  //vypise gratulaci pri uhodnuti

                }

            } while (tip != cislo);                       //konec smycky (cyklu) do-while, pokracuje dokud uzivatel neuhodne cislo
        }
    }
}
