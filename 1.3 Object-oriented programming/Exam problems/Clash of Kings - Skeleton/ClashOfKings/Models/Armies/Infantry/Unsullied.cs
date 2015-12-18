using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashOfKings.Models.Armies.Infantry
{
    using ClashOfKings.Attributes;

    [MilitaryUnit]
    public class Unsullied : MilitaryUnit
    {
        private const int DefaultUnsulliedArmor = 5;
        private const int DefaultUnsulliedDamage = 25;
        private const decimal DefaultUnsulliedTrainingCost = 42.5m;
        private const double DefaultUnsulliedUpkeepCost = 0.75;
        private const int DefaultUnsulliedHousingSpacesRequired = 1;
        private const UnitType DefaultUnsulliedUnitType = UnitType.Infantry;

        public Unsullied() 
            : base(
                  DefaultUnsulliedArmor,
                  DefaultUnsulliedDamage,
                  DefaultUnsulliedTrainingCost,
                  DefaultUnsulliedUpkeepCost,
                  DefaultUnsulliedHousingSpacesRequired,
                  DefaultUnsulliedUnitType)
        {
        }
    }
}
