using Problem_4.Software_University_Learning_System.People.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Software_University_Learning_System
{
    class OnlineStudent : CurrentStudent
    {
        public OnlineStudent(
            string firstName,
            string lastName,
            byte age,
            uint studentNumber,
            float grade,
            string currentCourse)
            : base(firstName, lastName, age, studentNumber, grade, currentCourse)
        {

        }
    }
}
