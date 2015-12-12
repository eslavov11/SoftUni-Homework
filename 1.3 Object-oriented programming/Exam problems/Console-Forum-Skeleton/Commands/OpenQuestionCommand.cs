using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;

namespace ConsoleForum.Commands
{
    public class OpenQuestionCommand : AbstractCommand
    {
        public OpenQuestionCommand(IForum forum) : base(forum)
        {
        }

        public override void Execute()
        {
            int questionId = int.Parse(this.Data[1]);
            var question = base.Forum.Questions.FirstOrDefault(x => x.Id == questionId);

            if (question == null)
            {
                throw new CommandException(Messages.NoQuestion);
            }

            this.Forum.Output.AppendLine(question.ToString());
        }
    }
}
