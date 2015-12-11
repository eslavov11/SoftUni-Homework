using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Contracts;

namespace WinterIsComing.Models.Spells
{
    public abstract class Spell : ISpell
    {
        public int Damage { get; set; }

        public virtual int EnergyCost { get; }
    }
}
