using System.Collections.Generic;
using ClashOfKings.Models.Armies;

namespace ClashOfKings.Models.Commands
{
    using System;
    using System.Linq;

    using ClashOfKings.Attributes;
    using ClashOfKings.Contracts;
    using ClashOfKings.Exceptions;

    [Command]

    public class CreateUnitCommand : Command
    {
        public CreateUnitCommand(IGameEngine engine) 
            : base(engine)
        {
        }

        public override void Execute(params string[] commandParams)
        {
            int numberOfUnits = int.Parse(commandParams[0]);
            string unitName = commandParams[1];
            ICity city = this.Engine.Continent.GetCityByName(commandParams[2]);
            ICollection<IMilitaryUnit> units = this.Engine.UnitFactory.CreateUnits(unitName, numberOfUnits);

            if (numberOfUnits < 0)
            {
                throw new ArgumentOutOfRangeException("Number of units should be a positive number");
            }

            if (city == null)
            {
                throw new ArgumentNullException(nameof(city));
            }

            if (city.AvailableUnitCapacity(units.First().Type) < units.Sum(u => u.HousingSpacesRequired))
            {
                throw new InsufficientHousingSpacesException(
                    $"City {city.Name} does not have enough housing spaces to accommodate" +
                    $" {numberOfUnits} units of {unitName}");
            }

            decimal totalMoneyToTrainUnits = units.Sum(x => x.TrainingCost);
            
            if (city.ControllingHouse.TreasuryAmount < totalMoneyToTrainUnits)
            {
                throw new InsufficientFundsException(
                    $"House {city.ControllingHouse.Name} does not have enough funds" +
                    $" to train {numberOfUnits} units of {unitName}");
            }

            city.ControllingHouse.TreasuryAmount -= totalMoneyToTrainUnits;
            city.AddUnits(units);

            this.Engine.Render($"Successfully added {numberOfUnits} units of {unitName} to city {commandParams[2]}");
        }
    }
}
