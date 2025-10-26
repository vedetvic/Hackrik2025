using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextUserInterface.Components
{
    /// <summary>
    /// Komponenta pro zadani cisla uzivatelem s titulkem a vyzvou
    /// </summary>
    public class InputBoxNumber: IComponent
    {
        public int ZIndex { get; set; } = 100;              //je treba pouzit vsechny vlastnosti a metody z rozhrani IComponent
        public string Name { get; set; } = "InputBoxNumber";
        public string Title { get; set; }                   //titulek vstupniho pole
        public string Prompt { get; set; }                  //vyzva pro uzivatele
        public int InputNumber { get; set; } = 0;       //ulozeni zadaneho cisla
        private int _width = 50;
        private int _height = 7;
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsRemoved { get; set; } = false;        

        public bool InputValid { get; set; } = false;       //indikator, zda byl vstup platny

        /// <summary>
        /// Konstruktor s parametry pro titulek a vyzvu
        /// </summary>
        /// <param name="title">Titulek pole</param>
        /// <param name="prompt">Vyzva pro uzivatele</param>
        public InputBoxNumber(string title, string prompt)
        {
            Title = title;
            Prompt = prompt;
            if (Prompt.Length + 4 > _width)                 //upravi sirku okna podle delky vyzvy
            {
                _width = Prompt.Length + 4;
            }
            X = (Console.WindowWidth - _width) / 2;         //vypocita pozici X pro vycentrovani okna
            Y = (Console.WindowHeight - _height) / 2;       //vypocita pozici Y pro vycentrovani okna
        }
        /// <summary>
        /// Metoda pro vykresleni komponenty na obrazovku
        /// </summary>
        public void Render()
        {
            List<string> lines = new List<string>();        //seznam radku pro vykresleni
            Console.SetCursorPosition(X, Y);                //nastavi kurzor na pozici X, Y
            lines.Add($"+=={Title} " + new string('=', _width - Title.Length - 5) + "+");   //pridani titulku
            lines.Add("|" + new string(' ', _width - 2) + "|");     //pridani prazdneho radku
            lines.Add("| " + Prompt.PadRight(_width - 4) + " |");   //pridani radku s vyzvou
            lines.Add("| " + InputNumber.ToString().PadRight(_width - 4) + " |");  //pridani radku se zadanym cislem
            lines.Add("|" + new string(' ', _width - 2) + "|");     //pridani prazdneho radku
            lines.Add("+" + new string('=', _width - 2) + "+");     //pridani spodniho okraje

            for (int i = 0; i < lines.Count; i++)                   //vykresleni jednotlivych radku na obrazovku
            {
                Console.SetCursorPosition(X, Y + i);                //nastavi kurzor na spravnou pozici
                Console.Write(lines[i]);                            //vypise radek na obrazovku
            }
        }
        /// <summary>
        /// Zpracovani vstupu uzivatele - nacteni cisla z konzole
        /// </summary>
        /// <returns>vraci true, ze byl vstup zpracovan</returns>
        public bool HandleInput()
        {
            Console.SetCursorPosition(X + 2, Y + 3);        //nastavi kurzor na radek pro zadani cisla
            Console.CursorVisible = true;                   //zobrazi kurzor
            string? input = Console.ReadLine();             //nacte vstup z konzole
            if (int.TryParse(input, out int number))        //pokusi se prevest vstup na cele cislo
            {
                InputNumber = number;                       //pokud se podarilo, ulozi cislo
                InputValid = true;                          //nastavi indikator platnosti vstupu na true

            }
            else
            {
                InputValid = false;                         //pokud se nepodarilo, nastavi indikator platnosti vstupu na false
            }
            Console.CursorVisible = false;                  //skryje kurzor
            IsRemoved = true;                               //oznaci komponentu jako odstranenu (uzavrenou)
            return true;                                    //vrati true, ze vstup byl zpracovan
        }
    }
}
