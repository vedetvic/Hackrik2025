using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextUserInterface;
using TextUserInterface.Components;

namespace ConsoleHadani
{
    public class TuiZobrazovac: IZobrazovac
    {
        public Screen obrazovka { get; set; }
        
        public TuiZobrazovac()
        {
            obrazovka = new Screen("Hadani cisel");
            obrazovka.Initialize();
        }
        public void ZobrazText(string zprava)
        {
            MessageBox Zprava=new MessageBox("Zprava", zprava);
            obrazovka.AddComponent(Zprava);
            obrazovka.Run();
        }

        public int NactiCislo(string vyzva)
        {
            InputBoxNumber Vstup=new InputBoxNumber("Vstup cisla", vyzva);
            
            do
            {
                obrazovka.AddComponent(Vstup);
                obrazovka.Run();
                if (!Vstup.InputValid)
                {
                    ZobrazText("Neplatný vstup. Zadejte prosim cele cislo.");
                }
            } while (!Vstup.InputValid);
            return Vstup.InputNumber;
        }

        public string NactiText(string vyzva)
        {
            InputBoxText Vstup=new InputBoxText("Vstup textu", vyzva);
            obrazovka.AddComponent(Vstup);
            obrazovka.Run();
            return Vstup.InputText;

        }
    }
}
