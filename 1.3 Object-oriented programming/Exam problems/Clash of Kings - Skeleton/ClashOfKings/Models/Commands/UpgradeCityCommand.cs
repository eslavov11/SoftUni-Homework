using System;
using System.Collections.Generic;
using ClashOfKings.Contracts;

namespace ClashOfKings.Models.Commands
{
    using System;
    using System.Linq;

    using ClashOfKings.Attributes;
    using ClashOfKings.Contracts;
    using ClashOfKings.Exceptions;

    [Command]

    public class UpgradeCityCommand : Command
    {
        public UpgradeCityCommand(IGameEngine engine) : base(engine)
        {
        }

        public override void Execute(params string[] commandParams)
        {
            ICity city = this.Engine.Continent.GetCityByName(commandParams[0]);
            
            if (city == null)
            {
                throw new ArgumentNullException(nameof(city));
            }

            if (city.CityType == CityType.Capital)
            {
                throw new InsufficientCitySizeException($"City {commandParams[0]} is at the maximum level and cannot be upgraded further");
            }

            if (city.ControllingHouse.TreasuryAmount < city.UpgradeCost && !(city.ControllingHouse is GreatHouse))
            {
                throw new InsufficientFundsException(
                    $"House {city.ControllingHouse.Name} has insufficient funds to upgrade {commandParams[0]}");
            }

            city.ControllingHouse.TreasuryAmount -= city.UpgradeCost;
            city.Upgrade();

            this.Engine.Render($"City {commandParams[0]} successfully upgraded to {city.CityType}");
        }
    }
}
