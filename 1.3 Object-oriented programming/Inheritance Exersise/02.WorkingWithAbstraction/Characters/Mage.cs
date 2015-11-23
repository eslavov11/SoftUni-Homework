using System;

namespace _02.WorkingWithAbstraction.Characters
{
    class Mage : Character
    {
        private static readonly int MageDamage = 100;
        private static readonly int MageHealth = 300;
        private static readonly int MageMana = 75;

        public Mage() : base(MageHealth, MageMana, MageDamage)
        {
        }


        public override void Attack(Character enemy)
        {
            this.Mana -= 100;
            enemy.Health -= this.Damage*2;
        }
    }
}
