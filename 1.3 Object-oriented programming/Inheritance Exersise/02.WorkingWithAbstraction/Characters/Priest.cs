using _02.WorkingWithAbstraction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.WorkingWithAbstraction.Characters
{
    class Priest : Character, IHeal
    {
        private static readonly int PriestDamage = 100;
        private static readonly int PriestHealth = 300;
        private static readonly int PriestMana = 75;

        public Priest() : base(PriestHealth, PriestMana, PriestDamage)
        {
        }


        public override void Attack(Character enemy)
        {
            enemy.Health -= this.Damage;
            this.Health += this.Damage / 10;
        }

        public void Heal(Character character)
        {
            this.Mana -= 100;
            character.Health += 150;
        }
    }
}
