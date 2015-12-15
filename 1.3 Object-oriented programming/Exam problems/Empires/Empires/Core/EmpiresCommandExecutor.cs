using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Interfaces;
using Empires.Models.Buildings;
using Empires.Models.Resources;
using Empires.Models.Units;

namespace Empires.Core
{
    public class EmpiresCommandExecutor : ICommandExecutor
    {
        private IDatabase db;

        public EmpiresCommandExecutor()
        {
            this.db = new EmpiresDatabase();
        }


        public string ExecuteCommand(ICommand command)
        {
            var output = new StringBuilder();

            switch (command.Name)
            {
                case CommandList.Build:
                    this.ExecuteBuildCommand(command.Parameters[0]);
                    break;
                case CommandList.Status:
                    output.Append(this.ExecuteStatusCommand());
                    break;
                default:
                    //throw new invalid command exception
                    break;
            }

            this.ProgressGame();

            return output.ToString();
        }

        private string ExecuteStatusCommand()
        {
            var statusResult = new StringBuilder();
            statusResult.AppendLine("Treasury:");
            statusResult.AppendLine("--Gold: " + this.db.Resources[ResourceType.Gold]);
            statusResult.AppendLine("--Steel: " + this.db.Resources[ResourceType.Steel]);

            statusResult.AppendLine("Buildings:");
            statusResult.AppendLine(db.Buildings.Any()
                ? string.Join(Environment.NewLine, db.Buildings)
                : "N/A");

            statusResult.Append("Units:");
            if (db.Units.Any())
            {
                if (db.Units.Any(u => u is Swordsman))
                {
                    statusResult.Append(Environment.NewLine + "--Swordsman: " + this.db.Units.Count(u => u is Swordsman));
                }

                if (db.Units.Any(u => u is Archer))
                {
                    statusResult.Append(Environment.NewLine + "--Archer: " + this.db.Units.Count(u => u is Archer));
                }
            }
            else
            {
                statusResult.Append(Environment.NewLine + "N/A");
            }

            return statusResult.ToString().TrimEnd('\r', '\n');
        }

        private void ExecuteBuildCommand(string buildingType)
        {
            switch (buildingType)
            {
                case CommandList.Archery:
                    this.db.Buildings.Add(new Archery());
                    break;
                case CommandList.Barracks:
                    this.db.Buildings.Add(new Barracks());
                    break;
                default:
                    //No such building exception
                    break;
            }
        }

        private void ProgressGame()
        {
            foreach (IBuilding building in db.Buildings)
            {
                building.Turn();
                IUnit unit = building.ProduceUnit();
                if (unit != null)
                {
                    db.Units.Add(unit);
                }
                IResource resource = building.ProduceResources();
                if (resource != null)
                {
                    db.Resources[resource.ResourceType] += resource.Quantity;
                }
            }
        }
    }
}
