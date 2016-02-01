namespace BangaloreUniversityLearningSystem.Views.CourseViews
{
    using System.Text;
    using Models;

    public class Enroll : View
    {
        public Enroll(Course course)
            : base(course)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Model as Course;
            viewResult.AppendFormat("Student successfully enrolled in course {0}.", course.Name).AppendLine();
        }
    }
}