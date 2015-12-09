using System;
using System.Linq;
using MassEffect.Exceptions;
using MassEffect.GameObjects.Locations;

namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;

    public class PlotJumpCommand : Command
    {
        public PlotJumpCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string shipName = commandArgs[1];
            string destinationName = commandArgs[2];

            IStarship ship = this.GameEngine.Starships.FirstOrDefault(s => s.Name == shipName);
            this.ValidateAlive(ship);

            var previousLocation = ship.Location;
            StarSystem destination = GameEngine.Galaxy.GetStarSystemByName(destinationName);

            if (previousLocation.Name == destinationName)
            {
                throw new ShipException(string.Format(Messages.ShipAlreadyInStarSystem, destinationName));
            }

            this.GameEngine.Galaxy.TravelTo(ship, destination);

            Console.WriteLine(Messages.ShipTraveled, shipName, previousLocation.Name, destinationName);
        }
    }
}
