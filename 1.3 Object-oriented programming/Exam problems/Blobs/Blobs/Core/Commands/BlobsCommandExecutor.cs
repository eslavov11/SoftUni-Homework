using Blobs.GameObjects.Behaviors;

namespace Blobs.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;
    using GameObjects.Attacks;
    using Models;
    using GameObjects.Behaviors;
    using System.Linq;
    using Exceptions;

    public class BlobsCommandExecutor : ICommandExecutor
    {
        private readonly IDatabase blobsDatabase;

        public BlobsCommandExecutor()
        {
            this.blobsDatabase = new BlobsDatabase();
        }


        public string Execute(ICommand command)
        {
            var output = new StringBuilder();
            
            switch (command.Name)
            {
                case EngineConstants.CreateBlobCommand:
                    this.ExecuteCreateCommand(command.Parameters);
                    break;
                case EngineConstants.AttackBlobCommand:
                    this.ExecuteAttackCommand(command.Parameters);
                    break;
                case EngineConstants.ExitCommand:
                    Environment.Exit(0);
                    break;
                case EngineConstants.StatusCommand:
                    output.Append(this.ExecuteStatusCommand());
                    break;
                case EngineConstants.SkipCommand:
                    break;
                case EngineConstants.ReportEventsCommand:
                    //TODO
                    break;
                default:
                    throw new InvalidCommandException("Invalid command");
            }
            
            this.ProgressGame();

            return output.ToString();
        }

        private void ExecuteAttackCommand(IList<string> parameters)
        {
            string attackerName = parameters[0];
            string targetName = parameters[1];

            IBlob attacker = this.blobsDatabase.Blobs.FirstOrDefault(b => b.Name == attackerName);
            IBlob target = this.blobsDatabase.Blobs.FirstOrDefault(b => b.Name == targetName);

            if (attacker == null)
            {
                throw new BlopNotFoundException($"Attacker blop {attackerName} does not exist");
            }

            if (target == null)
            {
                throw new BlopNotFoundException($"Target blop {targetName} does not exist");
            }

            attacker.PerformAttack(target);
        }

        private void ExecuteCreateCommand(IList<string> parameters)
        {
            string name = parameters[0];
            int health = int.Parse(parameters[1]);
            int damage = int.Parse(parameters[2]);
            string behaviorName = parameters[3];
            string attackName = parameters[4];

            IBehavior behavior = GetBehavior(behaviorName);
            IAttack attack = GetAttack(attackName);

            this.blobsDatabase.Blobs.Add(new Blob(name, health, damage, behavior, attack));
        }

        private string ExecuteStatusCommand()
        {
            StringBuilder output = new StringBuilder();
            output.Append(
                string.Join(Environment.NewLine, blobsDatabase.Blobs));
            return output.ToString();
        }

        private IBehavior GetBehavior(string behaviorName)
        {
            switch (behaviorName)
            {
                case "Aggressive":
                    return new AggressiveBehavior();
                case "Inflated":
                    return new InflatedBehavior();
                default:
                    throw new InvalidCommandException("No such aehavior");
            }
        }

        private IAttack GetAttack(string attackName)
        {
            switch (attackName)
            {
                case "PutridFart":
                    return new PutridFartAttack();
                case "Blobplode":
                    return new BlobplodeAttack();
                default:
                    throw new InvalidCommandException("No such attack");
            }
        }

        private void ProgressGame()
        {
            foreach (IBlob blob in blobsDatabase.Blobs)
            {
                if (!blob.BehaviorTriggeredInBattle)
                {
                    blob.UpdateBehavior();
                }
                else
                {
                    blob.BehaviorTriggeredInBattle = false;
                }
            }
        }
    }
}
