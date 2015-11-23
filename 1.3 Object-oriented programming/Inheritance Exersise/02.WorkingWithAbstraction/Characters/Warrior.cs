using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.WorkingWithAbstraction.Characters
{
    class Warrior : Character
    {
        private static readonly int WarriorDamage = 100;
        private static readonly int WarriorHealth = 300;
        private static readonly int WarriorMana = 75;

        public Warrior() : base(WarriorDamage, WarriorHealth, WarriorDamage)
        {
        }

        public override void Attack(Character enemy)
        {
            enemy.Health -= this.Damage;
        }
    }
}
