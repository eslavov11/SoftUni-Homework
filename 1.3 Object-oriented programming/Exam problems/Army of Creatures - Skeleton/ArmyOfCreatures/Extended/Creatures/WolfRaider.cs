using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Extended.Specialties;
using ArmyOfCreatures.Logic.Creatures;

namespace ArmyOfCreatures.Extended.Creatures
{
    public class WolfRaider : Creature
    {
        private const int DefaultWolfRaiderAttack = 8;
        private const int DefaultWolfRaiderDefense = 5;
        private const int DefaultWolfRaiderHealth = 10;
        private const decimal DefaultWolfRaiderDamage = 3.5m;
        private const int DefaultWolfRaiderDoubleDamage = 7;

        public WolfRaider() 
            : base(
                  DefaultWolfRaiderAttack, 
                  DefaultWolfRaiderDefense, 
                  DefaultWolfRaiderHealth, 
                  DefaultWolfRaiderDamage)
        {
            this.AddSpecialty(
                new DoubleDamage(
                    DefaultWolfRaiderDoubleDamage));
        }
    }
}
