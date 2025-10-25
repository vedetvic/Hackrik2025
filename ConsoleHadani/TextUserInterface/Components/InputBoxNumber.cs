using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextUserInterface.Components
{
    public class InputBoxNumber: IComponent
    {
        public int ZIndex { get; set; } = 100;
        public string Name { get; set; } = "InputBoxNumber";
        public string Title { get; set; }
        public string Prompt { get; set; }
        public int InputNumber { get; set; } = 0;
        private int _width = 50;
        private int _height = 7;
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsRemoved { get; set; } = false;

        public bool InputValid { get; set; } = false;

        public InputBoxNumber(string title, string prompt)
        {
            Title = title;
            Prompt = prompt;
            if (Prompt.Length + 4 > _width)
            {
                _width = Prompt.Length + 4;
            }
            X = (Console.WindowWidth - _width) / 2;
            Y = (Console.WindowHeight - _height) / 2;
        }
        public void Render()
        {
            List<string> lines = new List<string>();
            Console.SetCursorPosition(X, Y);
            lines.Add($"+=={Title} " + new string('=', _width - Title.Length - 5) + "+");
            lines.Add("|" + new string(' ', _width - 2) + "|");
            lines.Add("| " + Prompt.PadRight(_width - 4) + " |");
            lines.Add("| " + InputNumber.ToString().PadRight(_width - 4) + " |");
            lines.Add("|" + new string(' ', _width - 2) + "|");
            lines.Add("+" + new string('=', _width - 2) + "+");     
            
            for (int i = 0; i < lines.Count; i++)
            {
                Console.SetCursorPosition(X, Y + i);
                Console.Write(lines[i]);
            }
        }
        public bool HandleInput()
        {
            Console.SetCursorPosition(X + 2, Y + 3);
            Console.CursorVisible = true;
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int number))
            {
                InputNumber = number;
                InputValid = true;
                
            }
            else
            {
                InputValid = false;
            }
            Console.CursorVisible = false;
            IsRemoved = true;
            return true;
        }
    }
}
