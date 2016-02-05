namespace FactoryMethod.Factories
{
    using TankManufacturer.Units;

    public class RussianTankFactory : TankFactory
    {
        private const string DefaultRussianTankModel = "M1 52";
        private const double DefaultRussianTankSpeed = 5.4;
        private const int DefaultRussianTankDamage = 550;

        public override Tank CreateTank()
        {
            return new Tank(DefaultRussianTankModel,
                            DefaultRussianTankSpeed,
                            DefaultRussianTankDamage);
        }
    }
}
