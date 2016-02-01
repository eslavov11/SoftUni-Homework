namespace BangaloreUniversityLearningSystem.Views.Courses
{
    using System.Text;
    using Models;

    public class AddLecture : View
    {
        public AddLecture(Course course)
            : base(course)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Model as Course;
            viewResult.AppendFormat(
                "Lecture successfully added to course {0}.", course.Name).AppendLine();
        }
    }
}