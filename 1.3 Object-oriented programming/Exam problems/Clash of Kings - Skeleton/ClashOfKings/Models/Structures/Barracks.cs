using ClashOfKings.Models.Armies;
using ClashOfKings.Attributes;

namespace ClashOfKings.Models.Structures
{
    [ArmyStructure]
    public class Barracks : ArmyStructure
    {
        private const CityType DefaultBarracksRequiredCityType = CityType.Keep;
        private const decimal DefaultBarracksBuildCost = 15000;
        private const int DefaultBarracksCapacity = 5000;
        private const UnitType DefaultBarracksUnitType = UnitType.Infantry;

        public Barracks()
            : base(
                  DefaultBarracksRequiredCityType,
                  DefaultBarracksBuildCost,
                  DefaultBarracksCapacity,
                  DefaultBarracksUnitType)
        {
        }
    }
}
