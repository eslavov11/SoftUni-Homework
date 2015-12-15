using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Interfaces;
using Empires.Models.Buildings;

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
                case CommandList.Skip:
                    this.ExecuteSkipCommand();
                    break;
                case CommandList.Status:
                    output.AppendLine(this.ExecuteStatusCommand());
                    break;
                default:
                    //throw new invalid command exception
                    break;
            }

            return output.ToString();
        }

        private string ExecuteStatusCommand()
        {
            var statusResult = new StringBuilder();
            statusResult.AppendLine("Treasures:");
            statusResult.Append(string.Join(Environment.NewLine, db.Resources));

            statusResult.AppendLine("Buildings:");
            if (db.Units.Any())
            {
                statusResult.Append(string.Join(Environment.NewLine, db.Buildings));
            }
            else
            {
                statusResult.AppendLine("N/A");
            }

            statusResult.AppendLine("Units:");
            if (db.Units.Any())
            {
                statusResult.Append(string.Join(Environment.NewLine, db.Units));
            }
            else
            {
                statusResult.AppendLine("N/A");
            }
            
            return statusResult.ToString();
        }

        private void ExecuteSkipCommand()
        {
            throw new NotImplementedException();
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
            }
        }
    }
}
