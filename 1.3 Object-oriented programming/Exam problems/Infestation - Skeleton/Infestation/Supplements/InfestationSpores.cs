using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation.Supplements
{
    public class InfestationSpores : Supplement
    {
        public InfestationSpores()
        {
            base.PowerEffect = 1;
            base.AggressionEffect = 20;
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            throw new NotImplementedException();
        }
    }
}
