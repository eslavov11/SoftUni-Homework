using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Animals
{
    class Tomcat : Cat
    {
        public Tomcat(byte age, string gender, string name) : base(age, gender, name)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Tomcat said: "); base.ProduceSound();
        }
    }
}
