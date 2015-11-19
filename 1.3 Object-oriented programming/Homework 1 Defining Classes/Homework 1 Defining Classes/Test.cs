using static System.Console;

namespace Homework_1_Defining_Classes
{
    class Test
    {
        static void Main()
        {
            Person iliqn = new Person("Iliqn", 23);
            Person stoyan = new Person("Stoyo", 22, "stoyo@abv.bg");
            WriteLine(iliqn);
            WriteLine(stoyan);
        }
    }
}
