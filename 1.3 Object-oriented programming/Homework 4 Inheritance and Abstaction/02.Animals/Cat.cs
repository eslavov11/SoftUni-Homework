using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Animals
{
    class Cat : Animal
    {
        public Cat(byte age, string gender, string name) 
            : base(age, gender, name)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("MEOWWWW!");
        }
    }
}
