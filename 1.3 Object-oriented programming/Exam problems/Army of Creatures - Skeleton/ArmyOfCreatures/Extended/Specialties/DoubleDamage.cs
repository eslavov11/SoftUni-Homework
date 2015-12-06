using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic.Specialties;

namespace ArmyOfCreatures.Extended.Specialties
{
    public class DoubleDamage : Specialty
    {
        private int rounds;
        
        public DoubleDamage(int rounds)
        {
            this.Rounds = rounds;
        }
        
        public int Rounds
        {
            get { return this.rounds; }
            set {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Rounds cannot be a negative number!", "rounds");
                }
                if (value > 10)
                {
                    throw new ArgumentOutOfRangeException("Rounds cannot be a number greather than 10", "rounds");
                }
                this.rounds = value;
            }
        }

        public override void ApplyWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender)
        {
        }

        public override void ApplyWhenDefending(ICreaturesInBattle defenderWithSpecialty, ICreaturesInBattle attacker)
        {
        }

        public override void ApplyAfterDefending(ICreaturesInBattle defenderWithSpecialty)
        {
        }

        public override void ApplyOnSkip(ICreaturesInBattle skipCreature)
        {
        }

        public override decimal ChangeDamageWhenAttacking(
            ICreaturesInBattle attackerWithSpecialty,
            ICreaturesInBattle defender,
            decimal currentDamage)
        {
            if (attackerWithSpecialty == null)
            {
                throw new ArgumentNullException("attackerWithSpecialty");
            }

            if (defender == null)
            {
                throw new ArgumentNullException("defender");
            }

            if (this.Rounds <= 0)
            {
                // Effect expires after fixed number of rounds
                return currentDamage;
            }

            //attackerWithSpecialty.CurrentDefense *= 2;

            this.rounds--;
            return currentDamage * 2;
        }

        public override string ToString()
        {
            return $"DoubleDamage({this.Rounds})";
        }
    }
}
