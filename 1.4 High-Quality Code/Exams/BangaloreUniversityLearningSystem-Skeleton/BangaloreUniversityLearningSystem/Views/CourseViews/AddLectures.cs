namespace BangaloreUniversityLearningSystem.Views.CourseViews
{
    using System.Text;
    using Models;

    public class AddLectures : View
    {
        public AddLectures(Course course)
            : base(course)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Model as Course;
            viewResult.AppendFormat("Lecture successfully added to course {0}.", course.Name).AppendLine();
        }
    }
}