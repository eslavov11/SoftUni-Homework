using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;

namespace ConsoleForum.Entities.Posts
{
    public abstract class Post : IPost
    {
        protected Post(int id, string body)
        {
            this.Id = id;
            this.Body = body;
        }

        public int Id { get; set; }

        public string Body { get; set; }

        public IUser Author { get; set; }
    }
}
