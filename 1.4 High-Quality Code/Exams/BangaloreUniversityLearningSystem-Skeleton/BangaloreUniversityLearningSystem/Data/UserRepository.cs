namespace BangaloreUniversityLearningSystem.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class UsersRepository : Repository<User>
    {
        private Dictionary<string, User> usersByUsername;

        public UsersRepository()
        {
            this.usersByUsername = new Dictionary<string, User>();
        }
        
        // PERFORMANCE: Searching by username was done with Linq's first or default
        // from list, which is really slow opearation.
        public User GetByUsername(string username)
        {
            if (!this.usersByUsername.ContainsKey(username))
            {
                return null;
            }

            return this.usersByUsername[username];
        }

        public override void Add(User user)
        {
            this.usersByUsername.Add(user.Username, user);
        }
    }
}
