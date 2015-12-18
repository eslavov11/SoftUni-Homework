namespace ClashOfKings.Models.Commands
{
    using System;
    using System.Linq;

    using ClashOfKings.Attributes;
    using ClashOfKings.Contracts;
    using ClashOfKings.Exceptions;

    [Command]
    public class AddNeighborsToCityCommand : Command
    {
        public AddNeighborsToCityCommand(IGameEngine engine)
            : base(engine)
        {
        }

        public override void Execute(params string[] commandParams)
        {
            ICity city = this.Engine.Continent.GetCityByName(commandParams[0]);

            if (city == null)
            {
                throw new ArgumentNullException(nameof(city));
            }

            for (int i = 1; i < commandParams.Length; i += 2)
            {
                ICity neighbor = this.Engine.Continent.GetCityByName(commandParams[i]);

                try
                {
                    this.AddNeighborInfo(commandParams, neighbor, i, city);
                }
                catch (ArgumentNullException ex)
                {
                    this.Engine.Render(ex.Message);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    this.Engine.Render(ex.Message);
                }
            }

            this.Engine.Render($"All valid neighbor records added for city {city.Name}");
        }

        private void AddNeighborInfo(string[] commandParams, ICity neighbor, int i, ICity city)
        {
            if (neighbor == null)
            {
                throw new ArgumentNullException(nameof(neighbor), "Specified neighbor does not exist");
            }

            double distance = double.Parse(commandParams[i + 1]);

            if (distance < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(distance),
                    "The distance between cities cannot be negative");
            }

            this.Engine.Continent.CityNeighborsAndDistances[city].Add(neighbor, distance);
            this.Engine.Continent.CityNeighborsAndDistances[neighbor].Add(city, distance);
        }
    }
}
