using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextUserInterface
{
    public interface IComponent
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Name { get; set; }
        public int ZIndex { get; set; }
        public bool IsRemoved { get; set; }
        public void Render();
        public bool HandleInput();

    }
}
