using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;
using ConsoleForum.Entities.Posts;

namespace ConsoleForum.Commands
{
    public class PostAnswerCommand : AbstractCommand
    {
        public PostAnswerCommand(IForum forum) 
            : base(forum)
        {
        }

        public override void Execute()
        {
            if (this.Forum.CurrentUser == null)
            {
                throw new CommandException(Messages.NotLogged);
            }

            if (this.Forum.Questions == null)
            {
                throw new CommandException(Messages.NoQuestionOpened);
            }

            string body = this.Data[1];
            int id = this.Forum.Answers.OrderByDescending(x => x.Id).FirstOrDefault().Id;
            this.Forum.Answers.Add(new Answer(id,body));

            this.Forum.Output.AppendFormat(Messages.PostAnswerSuccess, id).AppendLine();
        }
    }
}
