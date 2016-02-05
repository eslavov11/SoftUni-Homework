namespace FactoryMethod.Factories
{
    using TankManufacturer.Units;

    public abstract class TankFactory
    {
        protected TankFactory()
        {
        }

        public abstract Tank CreateTank();
    }
}
