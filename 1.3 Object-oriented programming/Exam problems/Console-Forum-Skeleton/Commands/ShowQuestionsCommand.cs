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
                PrintQuestionsAndAnswers(question);
            }
        }

        private void PrintQuestionsAndAnswers(IQuestion question)
        {
            this.Forum.Output.AppendLine(question.ToString());
            var bestAnswer = question.Answers.FirstOrDefault(x => x is BestAnswer);
            if (bestAnswer != null)
            {
                this.Forum.Output.AppendLine(bestAnswer.ToString());
            }
            foreach (IAnswer answer in question.Answers.Where(answer => !(answer is BestAnswer)))
            {
                this.Forum.Output.AppendLine(answer.ToString());
            }
        }
    }
}
