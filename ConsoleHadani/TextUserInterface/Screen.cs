using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextUserInterface
{
    public class Screen
    {
        private int _width { get; set; }    
        private int _height { get; set; }
        private bool _isRunning { get; set; } = false;

        public int Width => _width;            
        public int Height => _height;
        public string Title { get; set; } = "Textová aplikace";

        private List<IComponent> _components = new List<IComponent>();

        public Screen()
        {
        
        }

        public Screen(string title)
        {
            Title = title;
        }

        
        /// <summary>
        /// Inicializuje obrazovku konzole s nastavenymi vlastnostmi
        /// </summary>
        public void Initialize()
        {
            Console.Title = Title;
            Console.Clear();
            _components = new List<IComponent>();
        }

        public void Run()
        {
            _isRunning = true;
            while (_isRunning)
            {
                Render();
                while (!HandleInput())
                {
                    Thread.Sleep(100);
                }
                RemoveComponents();
                if (_components.Count == 0)
                {
                    _isRunning = false;
                }
                
            }
        }

        public void Render()
        {
            Console.Clear();
            Console.CursorVisible = false;
            foreach (var component in _components.OrderBy(c => c.ZIndex))
            {
                component.Render();
                
            }
        }

        public void AddComponent(IComponent component)
        {
            _components.Add(component);
        }
        public void RemoveComponent(IComponent component) {
            _components.Remove(component);
        }

        public void RemoveComponents()
        {
            _components.RemoveAll(c => c.IsRemoved);
        }

        public bool HandleInput()
        {

            if (Console.KeyAvailable)
            {
                foreach (var component in _components.OrderByDescending(c => c.ZIndex))
                {
                    if (component.HandleInput())
                    {
                        return true;
                    }
                }
            }
            return false;


        }



    }
}
