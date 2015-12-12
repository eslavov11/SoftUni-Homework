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
        public Question(int id, IUser author, string title, string body) : base(id, author, body)
        {
            this.Title = title;
            this.Answers = new List<IAnswer>();
        }

        public string Title { get; set; }

        public IList<IAnswer> Answers { get; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"[ Question ID: {this.Id} ]" + Environment.NewLine +
                   $"Posted by: {this.Author.Username}" + Environment.NewLine +
                   $"Question Title: {this.Title}" + Environment.NewLine +
                   $"Question Body: {this.Body}" + Environment.NewLine +
                   $"====================");
            
            if (!this.Answers.Any())
            {
                result.Append("No answers");
                return result.ToString();
            }
            result.AppendLine("Answers:");
            IAnswer bestAnswer = this.Answers.FirstOrDefault(x => x is BestAnswer);
            if (bestAnswer != null)
            {
                result.AppendLine(bestAnswer.ToString());
            }
            foreach (IAnswer answer in this.Answers.Where(answer => !(answer is BestAnswer)).OrderBy(x => x.Id))
            {
                result.AppendLine(answer.ToString());
            }

            return result.ToString().TrimEnd('\r', '\n');
        }
    }
}
