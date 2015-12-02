using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.CustomLINQ
{
    class Test
    {
        static void Main(string[] args)
        {
            // WhereNot example
            var nums = new List<int>()
            {
                 1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };

            var filteredCollection = nums.WhereNot(x => x % 2 == 0);

            Console.WriteLine(string.Join(", ", filteredCollection));

            var students = new List<Student>()
            {
                new Student("Asya", 6),
                new Student("Ivan", 4),
                new Student("Penka", 5),
                new Student("Grigor", 3)
            };
            
            Console.WriteLine(students.Max(student => student.Grade));
            Console.WriteLine(students.Max(student => student.Name));
            
        }
    }


    public class Student
    {
        public Student(string name, int grade)
        {
            this.Name = name;
            this.Grade = grade;
        }

        public string Name { get; set; }

        public int Grade { get; set; }

        public override string ToString()
        {
            return $"Name: {this.Name}, Grade: {this.Grade}";
        }
    }
}
