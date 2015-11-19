using Problem_4.Software_University_Learning_System.People.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Software_University_Learning_System
{
    class OnsiteStudent : CurrentStudent
    {
        private ushort numberOfVisits;
        public OnsiteStudent(
            string firstName,
            string lastName,
            byte age,
            uint studentNumber,
            float grade,
            string currentCourse,
            ushort numberOfVisits)
            : base(firstName, lastName, age, studentNumber, grade, currentCourse)
        {

        }
    }
}
