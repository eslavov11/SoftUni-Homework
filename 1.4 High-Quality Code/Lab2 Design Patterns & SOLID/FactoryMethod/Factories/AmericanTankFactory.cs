namespace FactoryMethod.Factories
{
    using TankManufacturer.Units;

    public class AmericanTankFactory : TankFactory
    {
        private const string DefaultAmericanTankModel = "M1 Abrams";
        private const double DefaultAmericanTankSpeed = 5.4;
        private const int DefaultAmericanTankDamage = 120;

        public override Tank CreateTank()
        {
            return new Tank(DefaultAmericanTankModel, 
                            DefaultAmericanTankSpeed,
                            DefaultAmericanTankDamage);
        }
    }
}
