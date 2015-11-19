using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Software_University_Learning_System
{
    class DropoutStudent : Student
    {
        private string dropoutReason;

        public DropoutStudent(
            string firstName,
            string lastName,
            byte age,
            uint studentNumber,
            float grade,
            string dropoutReason)
            : base (firstName, lastName, age, studentNumber, grade)
        {
            this.DropoutReason = dropoutReason;
        }

        public string DropoutReason
        {
            get
            {
                return dropoutReason;
            }

            set
            {
                dropoutReason = value;
            }
        }

        public void Reapply()
        {
            Console.WriteLine("First name: {0}\nLast name: {1}\nAge: {2}\nStudent number: {3}\n"
                + "Average grade: {4}\nDropout reason: {5}\n",this.FirstName, this.LastName, this.Age, 
                this.StudentNumber, this.Grade, this.DropoutReason);
        }


        public override string ToString()
        {
            var result = base.ToString();
            result += "Dropout reason: " + this.DropoutReason + "\r\n";

            return result;
        }
    }
}
