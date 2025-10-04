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
        /// <summary>
        /// Spusti a zahraje jednu hru Hadani cisel
        /// </summary>
        public void Hraj()
        {
            Console.Clear();   //smaze obrazovku
            Console.WriteLine("Vitejte ve hre Hadani cisel!"); //vypise uvodni zpravu
            Console.WriteLine("Myslim si cislo od 1 do 100. Uhodni ho na co nejmene pokusu.");
            Random random = new Random(); //vytvori novy objekt pro generovani nahodnych cisel
            
            Vstup VlozeneCislo= new Vstup("Zadejte svuj tip: "); //vytvori novy objekt tridy Vstup s vyzvou pro uzivatele

            int cislo = random.Next(1, 101);  //vygeneruje nahodne cislo mezi 1 a 100
            int pokus = 0;  //pocitadlo pokusu
            int tip = 0;  //uzivateluv tip
            do
            {                                           //zacatek smycky (cyklu) do-while
                tip = VlozeneCislo.NactiCislo();        //nacte uzivateluv tip
                pokus++;                                 //zvysi pocitadlo pokusu o 1

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

            } while (tip != cislo);                       //konec smycky (cyklu) do-while, pokracuje dokud uzivatel neuhodne cislo
        }
    }
}
