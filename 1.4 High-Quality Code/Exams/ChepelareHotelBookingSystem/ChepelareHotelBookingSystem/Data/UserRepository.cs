namespace ChepelareHotelBookingSystem.Data
{
    using System;
    using System.Collections.Generic;

    using ChepelareHotelBookingSystem.Interfaces;
    using Models;

    public class UserRepository : Repository<User>, IUserRepository
    {
        private Dictionary<string, User> usersByUsername;

        public UserRepository()
        {
            this.usersByUsername = new Dictionary<string, User>();
        }

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
            base.Add(user);
        }

        public override bool Update(int id, User newUser)
        {
            var user = this.Get(id);
            if (user.Username != newUser.Username)
            {
                throw new InvalidOperationException("A user's username cannot be changed.");
            }

            if (base.Update(id, newUser))
            {
                this.usersByUsername[newUser.Username] = newUser;
                return true;
            }

            return false;
        }

        public override bool Delete(int id)
        {
            var user = this.Get(id);
            this.usersByUsername.Remove(user.Username);
            return base.Delete(id);
        }
    }
}
