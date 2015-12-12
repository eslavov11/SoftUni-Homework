using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;
using ConsoleForum.Entities.Posts;

namespace ConsoleForum.Commands
{
    public class PostQuestionCommand : AbstractCommand
    {
        public PostQuestionCommand(IForum forum) : base(forum)
        {
        }

        public override void Execute()
        {
            if (this.Forum.CurrentUser == null)
            {
                throw new CommandException(Messages.NotLogged);
            }

            string title = this.Data[1];
            string body = this.Data[2];
            int id = this.Forum.Questions.OrderByDescending(x => x.Id).FirstOrDefault().Id;
            this.Forum.Questions.Add(new Question(id, title, body));

            this.Forum.Output.AppendFormat(Messages.PostQuestionSuccess, id).AppendLine();

        }
    }
}
