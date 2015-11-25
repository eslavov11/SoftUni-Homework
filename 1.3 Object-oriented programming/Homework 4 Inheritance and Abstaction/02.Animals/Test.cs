using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Animals
{
    class Test
    {
        static void Main(string[] args)
        {
            Animal[] animals = {
                new Dog(15, "female", "Vulkan"),
                new Cat(20, "male", "Piss"),
                new Frog(13, "female", "Dzana"),
                new Kitten(5, "male", "Xoce"),
                new Tomcat(44, "male", "Tom") };

            animals[3].ProduceSound();

            Console.WriteLine(animals.Average(p => p.Age));
        }       
    }
}
