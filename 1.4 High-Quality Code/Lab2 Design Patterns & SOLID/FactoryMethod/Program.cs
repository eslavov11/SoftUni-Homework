namespace TankManufacturer
{
    using System;

    using FactoryMethod.Factories;

    using TankManufacturer.Units;

    class Program
    {
        static void Main()
        {
            TankFactory tankFactory = new GermanTankFactory();
            var tiger = tankFactory.CreateTank();

            Console.WriteLine(tiger);
        }
    }
}
