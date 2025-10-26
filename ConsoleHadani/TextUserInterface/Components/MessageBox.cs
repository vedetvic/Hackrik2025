using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextUserInterface.Components
{
    /// <summary>
    /// Komponenta pro zobrazeni zpravy s titulkem a potvrzeni uzivatelem
    /// </summary>
    public class MessageBox: IComponent
    {
        public int ZIndex { get; set; } = 100;              //vyska komponenty na obrazovce (vyssi cislo = vyssi vrstva)
        public string Name { get; set; } = "MessageBox";    //jmeno komponenty
        public string Title { get; set; }                   //titulek zpravy
        public string Message { get; set; }                 //obsah zpravy

        private int _width = 50;                            //sirka okna
        private int _height = 6;                            //vyska okna
        public int X { get; set; }                          //pozice X na obrazovce
        public int Y { get; set; }                          //pozice Y na obrazovce

        public bool IsRemoved { get; set; } = false;        //indikator, zda byla komponenta odstranena/uzavrena

        public MessageBox(string title, string message)     //konstruktor s parametry pro titulek a obsah zpravy
        {
            Title = title;
            Message = message;
            if (Message.Length + 4 > _width)                //upravi sirku okna podle delky zpravy
            {
                _width = Message.Length + 4;
            }
            X = (Console.WindowWidth - _width) / 2;         //vypocita pozici X pro vycentrovani okna
            Y = (Console.WindowHeight - _height) / 2;       //vypocita pozici Y pro vycentrovani okna
        }

        public void Render()                                //metoda pro vykresleni komponenty na obrazovku
        {
            List<string> lines = new List<string>();        //seznam radku pro vykresleni
            Console.SetCursorPosition(X, Y);                //nastavi kurzor na pozici X, Y
            lines.Add($"+=={Title} " + new string('=', _width - Title.Length - 5) + "+");   //pridani titulku
            lines.Add("|" + new string(' ', _width - 2) + "|");                             //pridani prazdneho radku
            lines.Add("| " + Message.PadRight(_width - 4) + " |");                          //pridani radku se zpravou
            lines.Add("|" + new string(' ', _width - 2) + "|");                             //pridani prazdneho radku
            lines.Add("+" + new string('=', _width - 2) + "+");                             //pridani spodniho okraje

            for (int i = 0; i < lines.Count; i++)           //vykresleni jednotlivych radku na obrazovku
            {
                Console.SetCursorPosition(X, Y + i);
                Console.Write(lines[i]);
            }


        }
        public bool HandleInput()                           //metoda pro zpracovani vstupu uzivatele
        {
            
            if (Console.KeyAvailable)                       //zkontroluje, zda je k dispozici nejaky vstup z klavesnice
            {
                Console.ReadKey(true);                      //precte stisknutou klavesu (true = nezobrazuje znak na obrazovce)
                IsRemoved = true;                           //nastavi indikator odstraneni komponenty na true (message box se po potvrzeni zavre)
                return true;                                //vrati true, ze vstup byl zpracovan
            }
            return false;                                   //vrati false, ze zadny vstup nebyl zpracovan
        }
    }
}
