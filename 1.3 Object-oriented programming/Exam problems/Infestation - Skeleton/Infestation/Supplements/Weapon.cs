using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation.Supplements
{
    public class Weapon : Supplement
    {
        public Weapon()
        {
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (!(otherSupplement is WeaponrySkill)) return;
            base.AggressionEffect = 3;
            base.PowerEffect = 10;
        }
    }
}
