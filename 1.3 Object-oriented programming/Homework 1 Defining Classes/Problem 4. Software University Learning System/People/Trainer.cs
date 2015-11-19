using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Software_University_Learning_System
{
    abstract class Trainer : Person
    {
        public Trainer(string firstName, string lastName, byte age) 
            : base(firstName, lastName, age)
        {

        }

        public void CreateCourse(string courseName)
        {
            Console.WriteLine("The course \"{0}\" has been created!", courseName);
        }
    }
}
