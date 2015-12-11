using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Core.Commands;

namespace WinterIsComing.Core
{
    public class ExtendedCommandDispatcher : CommandDispatcher
    {
        public override void SeedCommands()
        {
            this.commandsByName["toggle-effector"] = new ToggleEffectorCommand(base.Engine);
            base.SeedCommands();
        }
    }
}
