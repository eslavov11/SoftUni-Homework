namespace ClashOfKings.Models.Armies.Cavalry
{
    using ClashOfKings.Attributes;

    [MilitaryUnit]
    public class Dothraki : MilitaryUnit
    {
        private const int DefaultDothrakiArmor = 5;
        private const int DefaultDothrakiDamage = 25;
        private const decimal DefaultDothrakiTrainingCost = 25;
        private const double DefaultDothrakiUpkeepCost = 1.8;
        private const int DefaultDothrakiHousingSpacesRequired = 2;
        private const UnitType DefaultDothrakiUnitType = UnitType.Cavalry;

        public Dothraki() 
            : base(
                  DefaultDothrakiArmor,
                  DefaultDothrakiDamage,
                  DefaultDothrakiTrainingCost,
                  DefaultDothrakiUpkeepCost,
                  DefaultDothrakiHousingSpacesRequired,
                  DefaultDothrakiUnitType)
        {
        }
    }
}
