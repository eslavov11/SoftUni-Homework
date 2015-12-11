using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WinterIsComing.Models.Spells
{
    public class Stomp : Spell
    {
        public override int EnergyCost
        {
            get { return 10; }
        }
    }
}
