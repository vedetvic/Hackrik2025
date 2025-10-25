using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHadani
{
    /// <summary>
    /// trida pro zobrazeni textu v konzoli a nacteni vstupu od uzivatele v konzoli
    /// implementuje rozhrani IZobrazovac
    /// to znamena, ze musi obsahovat vsechny metody definovane v rozhrani IZobrazovac
    /// metody jiz maji konkretni implementaci pro konzoli (jednoduche vypisovani a cteni z konzole)
    /// </summary>
    public class ConsoleZobrazovac: IZobrazovac
    {
        public void ZobrazText(string zprava)
        {
            Console.WriteLine(zprava);
        }
        public int NactiCislo(string vyzva)
        {
            
            Vstup vstup = new Vstup(vyzva);
            return vstup.NactiCislo();
        }
        public string NactiText(string vyzva)
        {
            Vstup vstup = new Vstup(vyzva);
            return vstup.NactiText();
        }

    }
}
