using System;

namespace Infestation.Supplements
{
    public abstract class Supplement : ISupplement
    {
        public abstract void ReactTo(ISupplement otherSupplement);

        public int PowerEffect { get; protected set; }
        public int HealthEffect { get; protected set; }
        public int AggressionEffect { get; protected set; }
    }
}
