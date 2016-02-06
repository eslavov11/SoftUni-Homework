namespace BangaloreUniversityLearningSystem.Data
{
    using Interfaces;
    using Models;

    public class BangaloreUniversityData : IBangaloreUniversityData
    {
        public BangaloreUniversityData()
        {
            this.Users = new UsersRepository();
            this.Courses = new Repository<Course>();
        }

        public UsersRepository Users { get; }

        public IRepository<Course> Courses { get; }
    }
}
