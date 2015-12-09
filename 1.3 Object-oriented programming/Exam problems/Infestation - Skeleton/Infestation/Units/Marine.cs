using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infestation.Supplements;

namespace Infestation.Units
{
    public class Marine : Unit
    {
        private const int DefaultMarinePower = Human.HumanPower;
        private const int DefaultMarineHealth = Human.HumanHealth;
        private const int DefaultMarineAgression = Human.HumanAggression;
        private const UnitClassification DefaultMarineUnitClassification = UnitClassification.Biological;

        public Marine(string id) 
            : base(id, DefaultMarineUnitClassification, DefaultMarineHealth, DefaultMarinePower, DefaultMarineAgression)
        {
           base.AddSupplement(new WeaponrySkill());
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            return attackableUnits
                .Where(x => x.Power <= this.Aggression)
                .OrderByDescending(x => x.Health)
                .FirstOrDefault();
        }
    }
}
