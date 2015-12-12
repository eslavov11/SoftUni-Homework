using System.Linq;
using System.Net.Sockets;
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
            int id = this.Forum.Questions.Count + 1;
            this.Forum.Questions.Add(new Question(id, base.Forum.CurrentUser, title, body));

            this.Forum.Output.AppendFormat(Messages.PostQuestionSuccess, id).AppendLine();

        }
    }
}
