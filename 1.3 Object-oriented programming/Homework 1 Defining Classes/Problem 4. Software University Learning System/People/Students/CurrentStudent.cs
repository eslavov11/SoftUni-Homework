using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Software_University_Learning_System.People.Students
{
    abstract class CurrentStudent : Student
    {
        private string currentCourse;

        public CurrentStudent(
            string firstName, 
            string lastName, 
            byte age, 
            uint studentNumber, 
            float grade, 
            string currentCourse)
            : base (firstName, lastName, age, studentNumber, grade)
        {
            this.CurrentCourse = currentCourse;
        }


        public string CurrentCourse
        {
            get
            {
                return currentCourse;
            }

            set
            {
                currentCourse = value;
            }
        }

        public override string ToString()
        {
            var result = base.ToString();
            result += "Current course: " + this.CurrentCourse + "\r\n";

            return result;
        }
    }
}
