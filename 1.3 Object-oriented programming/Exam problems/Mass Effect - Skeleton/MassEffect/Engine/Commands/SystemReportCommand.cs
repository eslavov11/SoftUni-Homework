using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassEffect.Interfaces;

namespace MassEffect.Engine.Commands
{
    public class SystemReportCommand : Command
    {
        public SystemReportCommand(IGameEngine gameEngine) 
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string locationName = commandArgs[1];

            IEnumerable<IStarship> intactShips = this.GameEngine.Starships
                .Where(s => s.Location.Name == locationName)
                .Where(s => s.Health > 0)
                .OrderByDescending(s => s.Health)
                .ThenByDescending(s => s.Shields);

            StringBuilder result = new StringBuilder();
            result.AppendLine("Intact ships:");
            result.AppendLine(
                intactShips.Any() ?
                string.Join(Environment.NewLine, intactShips) : 
                "N/A");

            IEnumerable<IStarship> destroyedShips = this.GameEngine.Starships
                .Where(s => s.Location.Name == locationName)
                .Where(s => s.Health <= 0)
                .OrderBy(s => s.Name);
            
            result.AppendLine("Destroyed ships:");
            result.Append(
                destroyedShips.Any() ?
                string.Join(Environment.NewLine, destroyedShips) :
                "N/A");

            Console.WriteLine(result);
        }
    }
}
