using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;
using ConsoleForum.Entities.Posts;

namespace ConsoleForum.Commands
{
    public class MakeBestAnswerCommand : AbstractCommand
    {
        public MakeBestAnswerCommand(IForum forum) : base(forum)
        {
        }

        public override void Execute()
        {
            var id = int.Parse(this.Data[1]);

            if (!this.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }

            if (this.Forum.CurrentQuestion == null)
            {
                throw new CommandException(Messages.NoQuestionOpened);
            }

            if (this.Forum.CurrentUser != this.Forum.CurrentQuestion.Author)
            {
                if (!(this.Forum.CurrentUser is IAdministrator))
                {
                    throw new CommandException(Messages.NoPermission);
                }
            }

            var availBestAnswer = this.Forum.CurrentQuestion.Answers.FirstOrDefault(a => a.Id == id);
            if (availBestAnswer == null)
            {
                throw new CommandException(Messages.NoAnswer);
            }

            var curentBestAnswer = this.Forum.CurrentQuestion.Answers.FirstOrDefault(a => a is BestAnswer) as BestAnswer;
            if (curentBestAnswer != null)
            {
                if (curentBestAnswer.Id != id)
                {
                    var answer = new Answer(curentBestAnswer.Id, curentBestAnswer.Author, curentBestAnswer.Body);
                    this.ExchangeAnswers(curentBestAnswer, answer);
                }
            }
            else
            {
                this.Forum.Output.AppendLine(string.Format(Messages.BestAnswerSuccess, id));
                var bestAnswer = new BestAnswer(availBestAnswer.Id, availBestAnswer.Author, availBestAnswer.Body);
                this.ExchangeAnswers(availBestAnswer, bestAnswer);
            }
        }

        private void ExchangeAnswers(IAnswer curentBestAnswer, IAnswer answer)
        {
            var i = this.Forum.CurrentQuestion.Answers.IndexOf(curentBestAnswer);
            this.Forum.CurrentQuestion.Answers.RemoveAt(i);
            this.Forum.CurrentQuestion.Answers.Insert(i, answer);
            i = this.Forum.Answers.IndexOf(curentBestAnswer);
            this.Forum.Answers.RemoveAt(i);
            this.Forum.Answers.Insert(i, answer);
        }
    }
}
