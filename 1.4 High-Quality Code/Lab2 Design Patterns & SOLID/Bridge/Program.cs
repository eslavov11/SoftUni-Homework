namespace RPG
{
    using System;

    using RPG.Characters;
    using RPG.Weapons;

    public class Program
    {
        static void Main()
        {
            Character warrior = new Mage(new Sword());

            Console.WriteLine(warrior);
        }
    }
}
