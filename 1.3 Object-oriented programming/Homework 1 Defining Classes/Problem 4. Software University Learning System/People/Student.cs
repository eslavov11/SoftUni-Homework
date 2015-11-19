using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Software_University_Learning_System
{
    abstract class Student : Person
    {
        private uint studentNumber;
        private float grade;
        
        public Student(string firstName, string lastName, byte age, uint studentNumber, float grade)
            : base (firstName, lastName, age)
        {
            this.Grade = grade;
            this.StudentNumber = studentNumber;
        }

        public uint StudentNumber
        {
            get
            {
                return studentNumber;
            }

            set
            {
                studentNumber = value;
            }
        }

        public float Grade
        {
            get
            {
                return grade;
            }

            set
            {
                grade = value;
            }
        }

        public override string ToString()
        {
            var result = base.ToString();
            result += "Student number: " + this.StudentNumber + "\r\n";
            result += string.Format("Average grade: {0:f2}\r\n", this.Grade);

            return result;
        }
    }
}
