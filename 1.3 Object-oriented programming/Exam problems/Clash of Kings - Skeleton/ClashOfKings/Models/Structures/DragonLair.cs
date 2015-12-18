using ClashOfKings.Models.Armies;
using ClashOfKings.Attributes;

namespace ClashOfKings.Models.Structures
{
    [ArmyStructure]
    public class DragonLair : ArmyStructure
    {
        private const CityType DefaultDragonLairRequiredCityType = CityType.Capital;
        private const decimal DefaultDragonLairBuildCost = 200000;
        private const int DefaultDragonLairCapacity = 3;
        private const UnitType DefaultDragonLairUnitType = UnitType.AirForce;

        public DragonLair()
            : base(
                  DefaultDragonLairRequiredCityType,
                  DefaultDragonLairBuildCost,
                  DefaultDragonLairCapacity,
                  DefaultDragonLairUnitType)
        {
        }
    }
}
