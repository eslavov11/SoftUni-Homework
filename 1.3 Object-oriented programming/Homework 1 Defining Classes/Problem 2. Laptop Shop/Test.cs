using static System.Console;

namespace Problem_2.Laptop_Shop
{
    class Test
    {
        static void Main()
        {
            Laptop laptop1 = new Laptop("G510", 745.32m);
            WriteLine(laptop1);

            Laptop laptop2 = new Laptop("s50", "Lenovo", 899.55m, "Intel core i5");
            WriteLine(laptop2);

            Laptop laptop3 = new Laptop("F550", "Acer", "Intel core i3", "8 GB", 
                "Nvidia GeForce 2GB", "1000GB", "15.6\"", 1000.32m, new Battery("Li-ion", 6));
            WriteLine(laptop3);
        }
        
    }
}
