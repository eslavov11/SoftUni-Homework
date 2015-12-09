using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation.Supplements
{
    public abstract class Catalyst : Supplement
    {
        private const int HealthCatalyst = 3;
        private const int PowerCatalyst = 3;
        private const int AgressionCatalyst = 3;

        protected Catalyst()
        {
            
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
        }
    }
}
