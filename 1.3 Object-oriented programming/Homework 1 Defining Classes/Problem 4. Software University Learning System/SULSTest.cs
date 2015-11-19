using Problem_4.Software_University_Learning_System;
using Problem_4.Software_University_Learning_System.People.Students;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
class SULSTest
{
    static void Main(string[] args)
    {
        var juniorTrainer = new JuniorTrainer("Atanas", "Rusenov", 19);
        var seniorTrainer = new SeniorTrainer("Svetlin", "Nakov", 32);
        juniorTrainer.CreateCourse("Teamwork and personal skills");
        seniorTrainer.CreateCourse("Advanced C#");
        seniorTrainer.DeleteCourse("OOP");
        WriteLine();

        // test Reapply() method
        var applicant = new DropoutStudent("Prekusnal", "Student", 21, 1222, 3.03f, "Murzi me");
        applicant.Reapply();
        WriteLine();

        // Create a list of objects from each class
        var people = new List<Person>
            {
                new JuniorTrainer("Geogri", "Paskalev Jr.", 19),
                new SeniorTrainer("Ivan", "Ivanov Sr.", 45),
                new DropoutStudent("Misho", "Mihaylov", 25, 1234, 3.5f, "Mrazim da mislim"),
                new GraduateStudent("Viktor", "Kazakov", 31, 1235, 5.25f),
                new OnlineStudent("Elena", "Trendafilova", 23, 1236, 5.75f, "OOP"),
                new OnlineStudent("Pavleta", "Taseva", 21, 1237, 5.5f, "OOP"),
                new OnsiteStudent("Svetlin", "Nakov", 34, 1238, 6, "OOP", 15),
            };
        
        var sortedCurrentStudents =
            people.Where(a => a is CurrentStudent)
                .Cast<CurrentStudent>()
                .OrderBy(a => a.Grade);
        
        WriteLine("List of current students (sorted by average grade):");
        WriteLine();

        foreach (var student in sortedCurrentStudents)
        {
            WriteLine(student);
        }
    }
}

