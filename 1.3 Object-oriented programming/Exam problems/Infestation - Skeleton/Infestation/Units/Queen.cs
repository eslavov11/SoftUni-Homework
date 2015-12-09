using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infestation.Supplements;

namespace Infestation.Units
{
    public class Queen : Unit
    {
        public Queen(string id) 
            : base(id, UnitClassification.Psionic, 30, 1, 1)
        {
            base.AddSupplement(new InfestationSpores());
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            return attackableUnits
                .Where(x => x.Id != this.Id)
                .OrderBy(x => x.Health)
                .FirstOrDefault();
        }
    }
}
