using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextUserInterface
{
    /// <summary>
    /// Predstavuje zakladni rozhrani pro komponenty Textoveho Uzivatelskeho Rozhrani (TUI)
    /// Kazda komponenta musi implementovat vlastnosti pro pozici (X, Y), jmeno (Name), vrstvu zobrazeni (ZIndex) a stav odstraneni (IsRemoved)
    /// </summary>
    public interface IComponent
    {
        /// <summary>
        /// X-ova souradnice komponenty na obrazovce
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Y-ova souradnice komponenty na obrazovce
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// Nazev komponenty
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Vyska (vrstva) komponenty na obrazovce (vyssi cislo = vyssi vrstva) 
        /// </summary>
        public int ZIndex { get; set; }
        /// <summary>
        /// Indikator, zda byla komponenta odstranena z obrazovky (uzavrena)
        /// </summary>
        public bool IsRemoved { get; set; }
        /// <summary>
        /// Metoda pro vykresleni komponenty na obrazovku
        /// </summary>
        public void Render();
        /// <summary>
        /// Metoda pro zpracovani vstupu uzivatele
        /// </summary>
        /// <returns></returns>
        public bool HandleInput();

    }
}
