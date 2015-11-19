using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Software_University_Learning_System
{
    class SeniorTrainer : Trainer
    {
        public SeniorTrainer(string firstName, string secondName, byte age)
            : base (firstName, secondName, age)
        {

        }

        public void DeleteCourse(string course)
        {
            Console.WriteLine("The course \"{0}\" has been deleted!", course);
        }
    }
}
