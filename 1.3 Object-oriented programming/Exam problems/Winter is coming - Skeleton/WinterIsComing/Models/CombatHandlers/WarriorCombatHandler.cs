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
    public class WarriorCombatHandler : ICombatHandler
    {
        public WarriorCombatHandler(Warrior warrior)
        {
            this.Unit = warrior;
        }

        public IUnit Unit { get; set; }

        public IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            if (candidateTargets == null)
            {
                throw new ArgumentNullException("targets", "Target list can not be null");
            }
            return candidateTargets
                .OrderBy(x => x.HealthPoints)
                .ThenBy(x => x.Name)
                .Take(1);
            // TODO : check if is in range
        }

        public ISpell GenerateAttack()
        {

            var damage = this.Unit.AttackPoints;
            if (this.Unit.HealthPoints <= 80)
            {
                damage += 2 * this.Unit.HealthPoints;
            }

            var spell = new Cleave() {Damage = damage};
            if (this.Unit.EnergyPoints < spell.EnergyCost)
            {
                throw new NotEnoughEnergyException(
                    $"{this.Unit.Name} does not have enough energy to cast {this.GetType().Name}");
            }
            if (this.Unit.HealthPoints > 50)
            {
                this.Unit.EnergyPoints -= spell.EnergyCost;
            }

            return spell;
        }
    }
}
