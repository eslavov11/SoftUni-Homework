using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;

namespace ConsoleForum.Entities.Posts
{
    public class BestAnswer : Answer
    {
        public override string ToString()
        {
            return $"********************" + Environment.NewLine +
            base.ToString() + Environment.NewLine +
            $"********************"; ;
        }

        public BestAnswer(int id, IUser author, string body) : base(id, author, body)
        {
        }
    }
}
