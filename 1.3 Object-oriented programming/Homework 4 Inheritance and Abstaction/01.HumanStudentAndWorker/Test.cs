using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.HumanStudentAndWorker
{
    class Test
    {
        static void Main(string[] args)
        {
            List<Worker> workers = new List<Worker>();
            workers.Add(new Worker("Georgi", "Stoyanov", 500, 100));
            workers.Add(new Worker("Ruslana", "Velinova", 600, 100));
            workers.Add(new Worker("Ivan", "Mironov", 550, 100));
            workers.Add(new Worker("Venelin", "Raikovski", 2000, 100));
            workers.Add(new Worker("Miroslav", "Marinov", 350, 255));

            List<Student> students = new List<Student>();
            students.Add(new Student("Ognqn", "Stoyanov", "54152155"));
            students.Add(new Student("Geri", "Nikol", 6005100.ToString()));
            students.Add(new Student("Krisko", "Beats", 555452100.ToString()));
            students.Add(new Student("1000", "Kila", 200054100.ToString()));
            students.Add(new Student("Hose", "David", 35021255.ToString()));

            Console.WriteLine("Sorted by faculty number:");
            foreach (var student in students.OrderBy(p => p.FacultyNumber))
            {
                Console.WriteLine(student);
            }

            List<Human> people = new List<Human>();
            people.AddRange(workers);
            people.AddRange(students);

            Console.WriteLine("\nSorted by first and last name:");
            foreach (var human in people.OrderBy(p => p.FirstName).ThenBy(p => p.LastName))
            {
                Console.WriteLine(human);
            }

        }
    }
}
