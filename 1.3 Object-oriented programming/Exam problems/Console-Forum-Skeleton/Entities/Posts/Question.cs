using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;

namespace ConsoleForum.Entities.Posts
{
    public class Question : Post, IQuestion
    {
        public Question(int id, string title, string body) : base(id, body)
        {
            this.Title = title;
        }

        public string Title { get; set; }

        public IList<IAnswer> Answers { get; }

        public override string ToString()
        {
            return $"[ Question ID: {this.Id} ]" + Environment.NewLine +
                   $"Posted by: {this.Author}" + Environment.NewLine +
                   $"Question Title: {this.Title} " + Environment.NewLine +
                   $"Question Body: {this.Body} " + Environment.NewLine +
                   $"==================== ";
        }
    }
}
