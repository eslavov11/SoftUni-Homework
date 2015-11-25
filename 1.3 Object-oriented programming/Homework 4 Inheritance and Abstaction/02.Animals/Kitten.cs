using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Animals
{

    class Kitten : Cat
    {
        public Kitten(byte age, string gender, string name) : base(age, gender, name)
        {
        }

        public override void ProduceSound()
        {
            Console.Write("Little Kitten said: "); base.ProduceSound();
        }
    }
}
