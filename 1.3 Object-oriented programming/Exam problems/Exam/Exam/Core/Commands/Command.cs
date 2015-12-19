using System;
using Exam.Interfaces;

namespace Exam.Core.Commands
{
    public abstract class Command : ICommand
    {
        protected Command(Engine engine)
        {
            
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
