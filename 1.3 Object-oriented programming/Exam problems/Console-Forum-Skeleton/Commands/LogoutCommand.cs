using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;
using ConsoleForum.Utility;

namespace ConsoleForum.Commands
{
    public class LogoutCommand : AbstractCommand
    {
        public LogoutCommand(IForum forum) : base(forum)
        {
        }

        public override void Execute()
        {
            if (base.Forum.CurrentUser == null)
            {
                throw new CommandException(Messages.NotLogged);
            }

            base.Forum.Output.AppendFormat(Messages.LogoutSuccess).AppendLine();

            base.Forum.CurrentUser = null;
        }
    }
}
