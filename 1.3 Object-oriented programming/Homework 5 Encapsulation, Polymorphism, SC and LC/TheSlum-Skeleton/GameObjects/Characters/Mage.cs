using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSlum.Characters
{
    class Mage : AttackCharacter
    {
        private const int DefaultHealthPoints = 150;
        private const int DefaultDefencePoints = 50;
        private const int DefaultRange = 5;
        private const int DefaultAttackPoints = 300;

        public Mage(string id, int x, int y, Team team) 
            : base(id, x, y, DefaultHealthPoints, DefaultDefencePoints, team, DefaultRange)
        {
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            return targetsList.Where(x => x.IsAlive).Last(x => x.Team != this.Team);
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
            this.ApplyItemEffects(item);
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
            this.RemoveItemEffects(item);
        }

        public override string ToString()
        {
            return string.Format("{0}, Attack: {1}", base.ToString(), this.AttackPoints);
        }
    }
}
