using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;
using ConsoleForum.Entities.Posts;

namespace ConsoleForum.Commands
{
    public class ShowQuestionsCommand : AbstractCommand
    {
        public ShowQuestionsCommand(IForum forum) : base(forum)
        {
        }

        public override void Execute()
        {
            var questions = base.Forum.Questions;
            if (!questions.Any())
            {
                throw new CommandException(Messages.NoQuestions);
            }

            foreach (IQuestion question in questions)
            {
                this.Forum.Output.AppendLine(question.ToString());
            }
        }
    }
}
