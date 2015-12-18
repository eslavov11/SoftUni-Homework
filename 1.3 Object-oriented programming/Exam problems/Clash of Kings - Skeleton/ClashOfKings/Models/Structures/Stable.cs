using ClashOfKings.Models.Armies;
using ClashOfKings.Attributes;

namespace ClashOfKings.Models.Structures
{
    [ArmyStructure]
    public class Stable : ArmyStructure
    {
        private const CityType DefaultStableRequiredCityType = CityType.FortifiedCity;
        private const decimal DefaultStableBuildCost = 75000;
        private const int DefaultStableCapacity = 2500;
        private const UnitType DefaultStableUnitType = UnitType.Cavalry;

        public Stable()
            : base(
                  DefaultStableRequiredCityType,
                  DefaultStableBuildCost,
                  DefaultStableCapacity,
                  DefaultStableUnitType)
        {
        }
    }
}
