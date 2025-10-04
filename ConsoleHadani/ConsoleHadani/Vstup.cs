using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHadani
{
    /// <summary>
    /// Trida pro zpracovani vstupu od uzivatele
    /// </summary>
    public class Vstup
    {
        /// <summary>
        /// Zprava zobrazena uzivateli
        /// </summary>
        public string Zprava { get; set; }

        /// <summary>
        /// Konstruktor tridy Vstup. Inicializuje zpravu pro uzivatele.
        /// </summary>
        /// <param name="zprava">Obsahuje zpravu, ktera se bude zobrazovat uzivateli</param>
        public Vstup(string zprava)
        {
            Zprava = zprava;
        }

        /// <summary>
        /// Slouzi pro nacteni textu od uzivatele
        /// </summary>
        /// <returns>Nacteny text. Pokud dojde k chybe, vraci prazdny retezec.</returns>
        public string NactiText()
        {
            Console.Write(Zprava);              //zobrazi zpravu uzivateli
            string? text = Console.ReadLine();      //nacte text od uzivatele
            if (text == null) text = "";            //pokud uzivatel nezada zadny text, vrati prazdny retezec
            return text;                            //vrati nacteny text
        }

        /// <summary>
        /// Cte cele cislo od uzivatele. 
        /// Pokud uzivatel nezada platne cislo, zobrazi se chybova zprava a vyzve uzivatele k opakovani vstupu.
        /// </summary>
        /// <returns>Cislo nactene od uzivatele.</returns>
        public int NactiCislo()
        {
            int cislo;                              //promenna pro ulozeni nacteneho cisla
            while (true)                            //nekonecna smycka, dokud uzivatel nezada platne cislo
            {
                Console.Write(Zprava);              //zobrazi zpravu uzivateli
                string? text = Console.ReadLine();  //nacte text od uzivatele
                if (int.TryParse(text, out cislo))  //pokusi se prevest text na cele cislo
                {
                    return cislo;                   //pokud se podarilo, vrati cislo a ukonci smycku
                }
                else                                //pokud se nepodarilo, vypise chybovou zpravu a smycka pokracuje
                {
                    Console.WriteLine("Neplatny vstup. Zadejte cele cislo.");
                }
            }
        }

    }
}
