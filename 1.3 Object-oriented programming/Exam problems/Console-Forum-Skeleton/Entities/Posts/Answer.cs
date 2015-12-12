using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;

namespace ConsoleForum.Entities.Posts
{
    public class Answer : Post, IAnswer
    {
        public Answer(int id, string body) : base(id, body)
        {
        }

        public override string ToString()
        {
            return $"[ Answer ID: {this.Id} ]" + Environment.NewLine +
                   $"Posted by: {this.Author} " + Environment.NewLine +
                   $"Answer Body: {this.Body} " + Environment.NewLine +
                   $"--------------------";

        }
    }
}
