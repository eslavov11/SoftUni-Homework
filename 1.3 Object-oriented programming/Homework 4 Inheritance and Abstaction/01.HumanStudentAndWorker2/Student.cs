using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.HumanStudentAndWorker
{
    class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }
            set
            {
                if (this.facultyNumber.Length<5 || this.facultyNumber.Length>10)
                {
                    throw new ArgumentOutOfRangeException("Faculty number is invalid");
                }
                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            return this.FacultyNumber + " " + this.FirstName + " " + this.LastName;
        }
    }
}
