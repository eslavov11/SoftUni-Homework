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
            var body = this.Data[1];
            if (!this.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }

            if (this.Forum.CurrentQuestion == null)
            {
                throw new CommandException(Messages.NoQuestionOpened);
            }

            var answer = new Answer(this.Forum.Answers.Count + 1, this.Forum.CurrentUser, body);
            this.Forum.Output.AppendLine(string.Format(Messages.PostAnswerSuccess, answer.Id));
            this.Forum.Answers.Add(answer);
            this.Forum.CurrentQuestion.Answers.Add(answer);
        }
    }
}
