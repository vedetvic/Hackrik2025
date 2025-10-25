using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHadani
{
    public interface IZobrazovac
    {
        /// <summary>
        /// Zajisti zobrazeni textove zpravy uzivateli
        /// </summary>
        /// <param name="zprava">Zprava pro zobrazeni</param>
        public void ZobrazText(string zprava);
        /// <summary>
        /// Nacte cele cislo od uzivatele s vyzvou
        /// </summary>
        /// <param name="vyzva">Vyzva, ktera se zobrazi uzivateli</param>
        /// <returns>Nactene cislo</returns>
        public int NactiCislo(string vyzva);
        /// <summary>
        /// Nacte text od uzivatele s vyzvou
        /// </summary>
        /// <param name="vyzva">Vyzva, ktera se zobrazi uzivateli</param>
        /// <returns>Nacteny text</returns>
        public string NactiText(string vyzva);
    }
}
