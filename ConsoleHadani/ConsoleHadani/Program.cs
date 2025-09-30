//Hra hadani cisel

Console.Clear();
Console.WriteLine("Vitejte ve hre Hadani cisel!");
Console.WriteLine("Myslim si cislo od 1 do 100. Uhodni ho na co nejmene pokusu.");
Random random = new Random();
int cislo = random.Next(1, 101);
int pokus = 0;
int tip = 0;
do {     
    Console.Write("Zadejte svuj tip: ");
    string? vstup = Console.ReadLine();
    try
    {
        if (vstup == null)
        {
            Console.WriteLine("Neplatny vstup. Zadejte cele cislo mezi 1 a 100.");
            continue;
        }

        tip = int.Parse(vstup);

        if (tip < 1 || tip > 100)
        {
            Console.WriteLine("Cislo musi byt mezi 1 a 100. Zkuste to znovu.");
            continue;
        }
        pokus++;
    }
    catch (FormatException)
    {
        Console.WriteLine("Neplatny vstup. Zadejte cele cislo mezi 1 a 100.");
        continue;
    }
    if (tip < cislo)
    {
        Console.WriteLine("Moje cislo je vetsi. Zkuste to znovu.");
    }
    else if (tip > cislo)
    {
        Console.WriteLine("Moje cislo je mensi. Zkuste to znovu.");
    }
    else
    {
        Console.WriteLine($"Gratuluji! Uhodl jste cislo {cislo} na {pokus} pokusu.");
        
    }

} while (tip!=cislo);




