using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ConsoleForum.Contracts;
using ConsoleForum.Entities.Users;
using ConsoleForum.Utility;

namespace ConsoleForum.Commands
{
    public class LoginCommand : AbstractCommand
    {
        public LoginCommand(IForum forum) : base(forum)
        {
        }

        public override void Execute()
        {
            var users = this.Forum.Users;
            string username = this.Data[1];
            string password = PasswordUtility.Hash(this.Data[2]);

            var user = users.FirstOrDefault(x => x.Username == username &&  x.Password == password);

            if (user == null)
            {
                throw new CommandException(Messages.InvalidLoginDetails);
            }

            if (null != base.Forum.CurrentUser)
            {
                throw new CommandException(Messages.AlreadyLoggedIn);
            }

            base.Forum.CurrentUser = user;
            base.Forum.Output.AppendFormat(Messages.LoginSuccess, this.Forum.CurrentUser.Username).AppendLine();
        }
    }
}
