using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Student
{
    public class Student
    {
        public Student(string firstName, string lastName, int age, int facultyNumber, string phone, string email, IList<int> marks, int groupNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.FacultyNumber = facultyNumber;
            this.Phone = phone;
            this.Email = email;
            this.Marks = marks;
            this.GroupNumber = groupNumber;
        }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public int Age { set; get; }
        public int FacultyNumber { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public IList<int> Marks { set; get; }
        public int GroupNumber { set; get; }



        static void Main()
        {
            List<Student> students = new List<Student>()
        {
            new Student("Georgi", "Petrov",23, 510552, "+35989524533", "goshop@abv.bg",new List<int>(){6,2,3,5} ,1),
            new Student("Ivana", "Stoyanova",24, 510514, "+35911332653", "peisurce@gmail.com",new List<int>(){5,4,3,2} ,2),
            new Student("Geri", "Nikol",23, 510558, "+35924263233", "kutiqstaini@abv.bg",new List<int>(){3,4,2,2} ,2),
            new Student("Todor", "Alexandrov",24, 510552, "+35911332653", "peisurce@abv.bg",new List<int>(){5,4,3,2} ,2),
            new Student("Gergana", "Stamenova",23, 510514, "+35994263233", "kutiqstaini@abv.bg",new List<int>(){3,4,5,5} ,3),
            new Student("Polina", "Dardanova",24, 510552, "+465653265", "peisurce@abv.bg",new List<int>(){5,4,3,2} ,2),
            new Student("Viktor", "Iovchev",23, 510558, "+3592656133", "kutiqstaini@gmail.com",new List<int>(){3,4,5,5} ,2),
            new Student("Moti", "Karq",23, 510514, "+35946226462", "motikata@gmail.com",new List<int>(){6,2,3,5} ,4)
        };
            Console.WriteLine("Problem 1. Class Students");
            foreach (var student in students)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName + " " + student.Age + " " +
                student.FacultyNumber + " " + student.Phone + " " + student.Email + " " + String.Join(", ", student.Marks));
            }
            Console.WriteLine();


            Console.WriteLine("Problem 2. Students by Group");
            var groupedStudents = from gr in students where gr.GroupNumber == 2 orderby gr.FirstName select gr;
            foreach (var groupedStudent in groupedStudents)
            {
                Console.WriteLine(groupedStudent.FirstName + " " + groupedStudent.LastName + " " + groupedStudent.Age + " " +
                groupedStudent.FacultyNumber + " " + groupedStudent.Phone + " " + groupedStudent.Email + " " + String.Join(", ", groupedStudent.Marks));
            }

            Console.WriteLine();

            Console.WriteLine("Problem 3. Students by First and Last Name");
            var studentsByNames = students.Where(gr => gr.FirstName.CompareTo(gr.LastName) < 0);
            foreach (var groupedStudent in studentsByNames)
            {
                Console.WriteLine(groupedStudent.FirstName + " " + groupedStudent.LastName + " " + groupedStudent.Age + " " +
                groupedStudent.FacultyNumber + " " + groupedStudent.Phone + " " + groupedStudent.Email + " " + String.Join(", ", groupedStudent.Marks));
            }
            Console.WriteLine();

            Console.WriteLine("Problem 4. Students by Age");
            var studentsByAge =
                students.Where(gr => gr.Age >= 18 && gr.Age <= 24).Select(gr => new { gr.FirstName, gr.LastName, gr.Age });
            foreach (var groupedStudent in studentsByAge)
            {
                Console.WriteLine(groupedStudent.FirstName + " " + groupedStudent.LastName + " " + groupedStudent.Age);
            }
            Console.WriteLine();

            Console.WriteLine("Problem 5. Sort Students");
            // with LINQ syntax
            var sortStudentsLINQ =
                from st in students
                orderby st.FirstName descending, st.LastName descending
                select st; 
            // with lambda expressions
            var sortStudents = students.OrderByDescending(gr => gr.FirstName).ThenByDescending(gr => gr.LastName);
            foreach (var groupedStudent in sortStudentsLINQ)
            {
                Console.WriteLine(groupedStudent.FirstName + " " + groupedStudent.LastName + " " + groupedStudent.Age + " " +
                 groupedStudent.FacultyNumber + " " + groupedStudent.Phone + " " + groupedStudent.Email + " " + String.Join(", ", groupedStudent.Marks));
            }
            Console.WriteLine();

            Console.WriteLine("Problem 6. Filter Students by Email Domain");
            var studentsEmails =
               from gr in students
               where gr.Email.Contains("@abv.bg")
               select gr;
            foreach (var groupedStudent in studentsEmails)
            {
                Console.WriteLine(groupedStudent.FirstName + " " + groupedStudent.LastName + " " + groupedStudent.Age + " " +
                 groupedStudent.FacultyNumber + " " + groupedStudent.Phone + " " + groupedStudent.Email + " " + String.Join(", ", groupedStudent.Marks));
            }
            Console.WriteLine();

            Console.WriteLine("Problem 7. Filter Students by Phone");
            var studentsPhone =
                students.Where(
                    st => st.Phone.StartsWith("02") || st.Phone.StartsWith("+3592") || st.Phone.StartsWith("+359 2"));
            foreach (var groupedStudent in studentsPhone)
            {
                Console.WriteLine(groupedStudent.FirstName + " " + groupedStudent.LastName + " " + groupedStudent.Age + " " +
                 groupedStudent.FacultyNumber + " " + groupedStudent.Phone + " " + groupedStudent.Email + " " + String.Join(", ", groupedStudent.Marks));
            }
            Console.WriteLine();

            Console.WriteLine("Problem 8. Excellent Students");
            var excellentStudents =
               from st in students
               where (st.Marks.Max() == 6)
               select new { Fullname = string.Join(" ", st.FirstName, st.LastName), Marks = string.Join(" ", st.Marks) };
            foreach (var groupedStudent in excellentStudents)
            {
                Console.WriteLine(groupedStudent);
            }
            Console.WriteLine();

            Console.WriteLine("Problem 9. Weak Students");
            var weakStudents = students.Where(st => st.Marks.Count(x => x == 2) == 2);
            foreach (var groupedStudent in weakStudents)
            {
                Console.WriteLine(groupedStudent.FirstName + " " + groupedStudent.LastName + " " + groupedStudent.Age + " " +
                 groupedStudent.FacultyNumber + " " + groupedStudent.Phone + " " + groupedStudent.Email + " " + String.Join(", ", groupedStudent.Marks));
            }
            Console.WriteLine();

            Console.WriteLine("Problem 10. Students Enrolled in 2014");
            var students2014 =
                from st in students
                where (st.FacultyNumber % 100 == 14)
                select st;
            foreach (var groupedStudent in students2014)
            {
                Console.WriteLine(groupedStudent.FirstName + " " + groupedStudent.LastName + " " + groupedStudent.Age + " " +
                 groupedStudent.FacultyNumber + " " + groupedStudent.Phone + " " + groupedStudent.Email + " " + String.Join(", ", groupedStudent.Marks));
            }
            Console.WriteLine();
        }
    }
}
