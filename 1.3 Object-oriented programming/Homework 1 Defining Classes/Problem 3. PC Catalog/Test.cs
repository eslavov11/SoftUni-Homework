using System.Collections.Generic;
using static System.Console;

class Test
{
    static void Main()
    {
        var components1 = new List<Component>();
        components1.Add(new Component("CPU", 220.20m));
        components1.Add(new Component("HDD", 100.00m));
        Computer pc1 = new Computer("Lenovo", components1);

        var components2 = new List<Component>();
        components2.Add(new Component("Motherboard", 130.20m));
        components2.Add(new Component("HDD", 100.00m));
        Computer pc2 = new Computer("Toshiba", components2);

        var components3= new List<Component>();
        components3.Add(new Component("RAM", 150.00m));
        components3.Add(new Component("HDD", 100.00m));
        Computer pc3 = new Computer("Acer", components3);

        List<Computer> catalog = new List<Computer>();
        catalog.Add(pc1);
        catalog.Add(pc2);
        catalog.Add(pc3);
        catalog.Sort();

        foreach (var item in catalog)
        {
            WriteLine(item);
        }

    }
}

