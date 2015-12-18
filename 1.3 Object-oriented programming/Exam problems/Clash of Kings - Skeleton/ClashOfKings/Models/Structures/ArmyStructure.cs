using ClashOfKings.Contracts;
using ClashOfKings.Models.Armies;

namespace ClashOfKings.Models.Structures
{
    public abstract class ArmyStructure : IArmyStructure
    {
        private decimal buildingCost;
        private int capacity;

        protected ArmyStructure(CityType cType, decimal buildCost, int capacity, UnitType unitType)
        {
            this.RequiredCityType = cType;
            this.BuildCost = buildCost;
            this.Capacity = capacity;
            this.UnitType = unitType;
        }

        public CityType RequiredCityType { get; }


        //TODO: validate
        public decimal BuildCost
        {
            get { return this.buildingCost; }
            set { this.buildingCost = value; }
        }

        public int Capacity
        {
            get { return this.capacity; }
            set { this.capacity = value; }
        }

        public UnitType UnitType { get; }
        
    }
}
