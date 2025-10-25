using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextUserInterface.Components
{
    public class MessageBox: IComponent
    {
        public int ZIndex { get; set; } = 100;
        public string Name { get; set; } = "MessageBox";
        public string Title { get; set; }
        public string Message { get; set; }

        private int _width = 50;
        private int _height = 6;
        public int X { get; set; }
        public int Y { get; set; }

        public bool IsRemoved { get; set; } = false;

        public MessageBox(string title, string message)
        {
            Title = title;
            Message = message;
            if (Message.Length + 4 > _width)
            {
                _width = Message.Length + 4;
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
            lines.Add("| " + Message.PadRight(_width - 4) + " |");
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
            
            if (Console.KeyAvailable)
            {
                Console.ReadKey(true); 
                IsRemoved = true;
                return true; 
            }
            return false;
        }
    }
}
