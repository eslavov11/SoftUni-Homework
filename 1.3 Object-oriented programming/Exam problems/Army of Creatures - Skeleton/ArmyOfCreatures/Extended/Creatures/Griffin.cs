using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Logic.Specialties;

namespace ArmyOfCreatures.Extended.Creatures
{
    public class Griffin : Creature
    {
        private const int DefaultGoblinAttack = 8;
        private const int DefaultGoblinDefense = 8;
        private const int DefaultGoblinHealth = 25;
        private const decimal DefaultGoblinDamage = 4.5m;

        private const int DefaultGriffinDoubleDefenseWhenDefending = 5;
        private const int DefaultAddDefenseWhenSkip = 3;

        public Griffin() 
            : base(DefaultGoblinAttack, DefaultGoblinDefense, DefaultGoblinHealth, DefaultGoblinDamage)
        {
            this.AddSpecialty(
                new DoubleDefenseWhenDefending(
                    DefaultGriffinDoubleDefenseWhenDefending));
            this.AddSpecialty(
                new AddDefenseWhenSkip(
                    DefaultAddDefenseWhenSkip));
            this.AddSpecialty(new Hate(typeof(WolfRaider)));
        }

        
    }
}
