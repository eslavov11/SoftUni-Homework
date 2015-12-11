using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterIsComing.Models.Spells
{
    public class Blizzard : Spell
    {
        public override int EnergyCost
        {
            get { return 40; }
        }
    }
}
