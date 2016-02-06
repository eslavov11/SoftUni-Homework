namespace BangaloreUniversityLearningSystem.Interfaces
{
    using Data;
    using Models;

    public interface IBangaloreUniversityData
    {
        UsersRepository Users { get; }

        IRepository<Course> Courses { get; }
    }
}