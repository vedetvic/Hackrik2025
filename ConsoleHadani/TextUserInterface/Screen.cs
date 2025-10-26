using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextUserInterface
{
    /// <summary>
    /// Reprezentuje prostor obrazovky konzole pro textove uzivatelske rozhrani (TUI)
    /// Uvnitr spravuje komponenty implementujici rozhrani IComponent
    /// </summary>
    public class Screen
    {
        /// <summary>
        /// sirka obrazovky konzole
        /// </summary>
        private int _width { get; set; }
        /// <summary>
        /// vyska obrazovky konzole
        /// </summary>
        private int _height { get; set; }
        /// <summary>
        /// indikator, zda je obrazovka aktualne spustena
        /// </summary>
        private bool _isRunning { get; set; } = false;
        /// <summary>
        /// verejny pristup k sirce obrazovky
        /// </summary>
        public int Width => _width;
        /// <summary>
        /// verejny pristup k vysce obrazovky
        /// </summary>
        public int Height => _height;
        /// <summary>
        /// Titulek konzolove aplikace
        /// </summary>
        public string Title { get; set; } = "Textová aplikace";

        /// <summary>
        /// Seznam komponent na obrazovce
        /// </summary>
        private List<IComponent> _components = new List<IComponent>();

        /// <summary>
        /// Defaultni konstruktor obrazovky
        /// </summary>
        public Screen()
        {
        
        }

        /// <summary>
        /// Konstruktor obrazovky s parametrem titulku
        /// </summary>
        /// <param name="title">Titulek konzoloveho okna</param>
        public Screen(string title)
        {
            Title = title;
        }

        
        /// <summary>
        /// Inicializuje obrazovku konzole s nastavenymi vlastnostmi
        /// </summary>
        public void Initialize()
        {
            Console.Title = Title;                  //nastaveni titulku konzole
            Console.Clear();                        //smazani obrazovky
            _components = new List<IComponent>();   //inicializace seznamu komponent
        }

        /// <summary>
        /// Zajistuje hlavni smycku behu obrazovky
        /// Postupne vykresluje komponenty a zpracovava jejich vstupy
        /// </summary>
        public void Run()
        {
            _isRunning = true;                  //nastaveni stavu behu obrazovky
            while (_isRunning)                  //hlavni smycka behu obrazovky
            {
                Render();                       //vykresleni vsech komponent na obrazovku
                while (!HandleInput())          //zpracovani vstupu uzivatele
                {
                    Thread.Sleep(100);          //kratka pauza pro snizeni vytizeni CPU
                }
                RemoveComponents();             //odstraneni komponent oznacenych k odstraneni
                if (_components.Count == 0)     //pokud nejsou zadne komponenty, ukonci beh obrazovky
                {
                    _isRunning = false;         //nastaveni stavu behu obrazovky na false
                }
                
            }
        }
        /// <summary>
        /// VYkresli vsechny komponenty na obrazovku podle jejich ZIndexu
        /// </summary>
        public void Render()
        {
            Console.Clear();                    //smazani obrazovky
            Console.CursorVisible = false;      //skryti kurzoru
            foreach (var component in _components.OrderBy(c => c.ZIndex))   //vykresleni komponent podle jejich ZIndexu
            {
                component.Render();             //vykresleni jednotlive komponenty pomoci jeji Render metody

            }
        }

        /// <summary>
        /// Prida komponentu na obrazovku
        /// </summary>
        /// <param name="component">Pridavana komponenta</param>
        public void AddComponent(IComponent component)
        {
            _components.Add(component);
        }
        /// <summary>
        /// Odstrani komponentu z obrazovky
        /// </summary>
        /// <param name="component">odstranovana komponenta</param>
        public void RemoveComponent(IComponent component) {
            _components.Remove(component);
        }

        /// <summary>
        /// odstrani vsechny komponenty oznacene k odstraneni (IsRemoved = true)
        /// </summary>
        public void RemoveComponents()
        {
            _components.RemoveAll(c => c.IsRemoved);    //odstrani vsechny komponenty, ktere maji IsRemoved nastaveno na true
        }

        /// <summary>
        /// Zpracuje vstup uzivatele pro vsechny komponenty podle jejich ZIndexu
        /// Vstupy se zpracuji v opacnem poradi nez jsou vykresleny (vyssi ZIndex ma prednost)
        /// Komponenta nahore zpracovava vstup jako prvni
        /// Jestlize komponenta zpracuje vstup (je urcen pro ni), zpracovani se ukonci
        /// </summary>
        /// <returns>Informace, zdali byl zpracovan nejaky vstup</returns>
        public bool HandleInput()
        {

            if (Console.KeyAvailable)       //zkontroluje, zda je k dispozici nejaky vstup z klavesnice
            {
                foreach (var component in _components.OrderByDescending(c => c.ZIndex)) //zpracovani vstupu podle ZIndexu (vyssi ZIndex ma prednost)
                {
                    if (component.HandleInput())           //pokusi se zpracovat vstup v komponente pomoci jeji HandleInput metody
                    {
                        return true;                        //pokud komponenta zpracovala vstup, vrati true
                    }
                }
            }
            return false;                                   //zadny vstup nebyl zpracovan, vrati false


        }



    }
}
