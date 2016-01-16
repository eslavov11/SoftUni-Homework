namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Course
    {
        private string name;

        protected Course(string name) 
            : this(name, null)
        {
        }

        protected Course(string courseName, string teacherName)
            : this(courseName, teacherName, new List<string>())
        {
        }

        protected Course(string courseName, string teacherName, IList<string> students)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(
                        "name",
                        "The courseName of the course cannot be empty.");
                }

                this.name = value;
            }
        }

        public string TeacherName { get; set; }

        public IList<string> Students { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("{ courseName = ");
            result.Append(this.Name);

            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());

            return result.ToString();
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}
