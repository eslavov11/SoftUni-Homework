namespace ClashOfKings.Models.Commands
{
    using System;
    using System.Linq;

    using ClashOfKings.Attributes;
    using ClashOfKings.Contracts;
    using ClashOfKings.Exceptions;

    [Command]
    public class BuildStructureCommand : Command
    {
        public BuildStructureCommand(IGameEngine engine) 
            : base(engine)
        {
        }

        public override void Execute(params string[] commandParams)
        {
            string structureName = commandParams[0];
            string cityName = commandParams[1];

            IArmyStructure structure = this.Engine.ArmyStructureFactory.CreateStructure(structureName);
            ICity city = this.Engine.Continent.GetCityByName(cityName);

            if (city == null)
            {
                throw new ArgumentNullException(nameof(city));
            }

            if (city.CityType < structure.RequiredCityType)
            {
                throw new InsufficientCitySizeException("Structure requires a more advanced city");
            }

            if (city.ControllingHouse.TreasuryAmount < structure.BuildCost)
            {
                throw new InsufficientFundsException(
                    $"House {city.ControllingHouse.Name} doesn't have sufficient funds" +
                    $" to build {structure.GetType().Name}");
            }

            city.ControllingHouse.TreasuryAmount -= structure.BuildCost;
            city.AddArmyStructure(structure);

            this.Engine.Render($"Successfully built {structureName} in {cityName}");
        }
    }
}
