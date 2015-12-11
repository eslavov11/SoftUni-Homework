using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterIsComing.Models.Spells
{
    public class Cleave : Spell
    {
        public override int EnergyCost
        {
            get { return 15; } 
        }
    }
}
