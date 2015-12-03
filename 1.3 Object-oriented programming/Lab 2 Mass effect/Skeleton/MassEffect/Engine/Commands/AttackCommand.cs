using System;
using System.Linq;
using MassEffect.Exceptions;

namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;

    public class AttackCommand : Command
    {
        public AttackCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string atcShipName = commandArgs[1];
            string defShipName = commandArgs[2];

            var attackShip = this.GameEngine.Starships.FirstOrDefault(s => s.Name == atcShipName);
            var defenceShip = this.GameEngine.Starships.FirstOrDefault(s => s.Name == defShipName);

            this.ProcessStarShipBattle(attackShip, defenceShip);
        }

        private void ProcessStarShipBattle(IStarship attackShip, IStarship defenceShip)
        {
            base.ValidateAlive(attackShip);
            base.ValidateAlive(defenceShip);

            if (attackShip.Location.Name != defenceShip.Location.Name)
            {
                throw new LocationOutOfRangeException(Messages.NoSuchShipInStarSystem);
            }

            IProjectile attack = attackShip.ProduceAttack();
            defenceShip.RespondToAttack(attack);

            Console.WriteLine(Messages.ShipAttacked, attackShip.Name, defenceShip.Name);

            if (defenceShip.Shields < 0)
            {
                defenceShip.Shields = 0;
            }

            if (defenceShip.Health < 0)
            {
                defenceShip.Health = 0;
                Console.WriteLine(Messages.ShipDestroyed, defenceShip.Name);
            }
        }

        
    }
}
