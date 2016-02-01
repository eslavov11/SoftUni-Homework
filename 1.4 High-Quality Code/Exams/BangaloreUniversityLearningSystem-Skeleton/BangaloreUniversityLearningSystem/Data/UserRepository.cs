namespace BangaloreUniversityLearningSystem.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using BangaloreUniversityLearningSystem.Models;

    public class UsersRepository : Repository<User>
    {
        private Dictionary<string, User> usersByUsername;

        public User GetByUsername(string username)
        {
            return this.Items.FirstOrDefault(u => u.Username == username);
        }
    }
}
