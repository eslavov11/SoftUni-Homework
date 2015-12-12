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
    public class MageCombatHandler : ICombatHandler
    {
        private static int spellIndex = 0;

        public MageCombatHandler(Mage mage)
        {
            this.Unit = mage;
        }

        public IUnit Unit { get; set; }

        public IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            if (candidateTargets == null)
            {
                throw new ArgumentNullException("targets", "Target list can not be null");
            }
            return candidateTargets.OrderByDescending(x => x.HealthPoints)
                .ThenBy(x => x.Name)
                .Take(3);
        }

        public ISpell GenerateAttack()
        {
            if (spellIndex == 0)
            {
                FireBreath mageSpell = new FireBreath {Damage = this.Unit.AttackPoints};

                if (this.Unit.EnergyPoints < mageSpell.EnergyCost)
                {
                    throw new NotEnoughEnergyException(
                        $"{this.Unit.Name} does not have enough energy to cast {mageSpell.GetType().Name}");
                }

                this.Unit.EnergyPoints -= mageSpell.EnergyCost;

                spellIndex = 1;
                
                return mageSpell;
            }
            else
            {
                Blizzard mageSpell = new Blizzard {Damage = this.Unit.AttackPoints*2};

                if (this.Unit.EnergyPoints < mageSpell.EnergyCost)
                {
                    throw new NotEnoughEnergyException(
                        $"{this.Unit.Name} does not have enough energy to cast {mageSpell.GetType().Name}");
                }

                this.Unit.EnergyPoints -= mageSpell.EnergyCost;

                spellIndex = 0;
                
                return mageSpell;
            }

            
        }
    }
}
