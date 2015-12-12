using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Contracts;
using WinterIsComing.Core.Exceptions;
using WinterIsComing.Models.Spells;
using WinterIsComing.Models.Units;

namespace WinterIsComing.Models.CombatHandlers
{
    public class IceGiantCombatHandler : ICombatHandler
    {
        public IceGiantCombatHandler(IceGiant iceGiant)
        {
            this.Unit = iceGiant;
        }

        public IUnit Unit { get; set; }

        public IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            if (candidateTargets == null)
            {
                throw new ArgumentNullException("targets", "Target list can not be null");
            }
            return this.Unit.HealthPoints <= 150 ? candidateTargets.Take(1) : candidateTargets;
        }

        public ISpell GenerateAttack()
        {
            Stomp iceGiantStomp = new Stomp();

            if (this.Unit.EnergyPoints < iceGiantStomp.EnergyCost)
            {
             throw new NotEnoughEnergyException(
                 $"{this.Unit.Name} does not have enough energy to cast {this.GetType().Name}");
            }
            
            iceGiantStomp.Damage = this.Unit.AttackPoints;
            this.Unit.EnergyPoints -= iceGiantStomp.EnergyCost;
            this.Unit.AttackPoints += 5;
            return iceGiantStomp;
        }

    }
}
