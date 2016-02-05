namespace FactoryMethod.Factories
{
    using TankManufacturer.Units;

    public class GermanTankFactory : TankFactory
    {
        private const string DefaultGermanTankModel = "Tiger";
        private const double DefaultGermanTankSpeed = 4.5;
        private const int DefaultGermanTankDamage = 120;

        public override Tank CreateTank()
        {
            return new Tank(DefaultGermanTankModel,
                            DefaultGermanTankSpeed,
                            DefaultGermanTankDamage);
        }
    }
}
