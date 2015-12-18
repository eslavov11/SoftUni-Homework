namespace ClashOfKings.Models.Armies.AirForce
{
    using ClashOfKings.Attributes;

    [MilitaryUnit]
    public class Dragon : MilitaryUnit
    {
        private const int DefaultDragonArmor = 700;
        private const int DefaultDragonDamage = 1200;
        private const decimal DefaultDragonTrainingCost = 1500;
        private const double DefaultDragonUpkeepCost = 100;
        private const int DefaultDragonHousingSpacesRequired = 1;
        private const UnitType DefaultDragonUnitType = UnitType.AirForce;

        public Dragon() 
            : base(
                  DefaultDragonArmor, 
                  DefaultDragonDamage, 
                  DefaultDragonTrainingCost, 
                  DefaultDragonUpkeepCost,
                  DefaultDragonHousingSpacesRequired,
                  DefaultDragonUnitType)
        {
        }
    }
}
