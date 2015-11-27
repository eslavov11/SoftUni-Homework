using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSlum.Interfaces;

namespace TheSlum.Characters
{
    class Healer : Character, IHeal
    {
        private const int DefaultHealthPoints = 75;
        private const int DefaultDefencePoints = 50;
        private const int DefaultRange = 6;

        private int defaultHealPoints = 60;

        public Healer(string id, int x, int y, Team team) 
            : base(id, x, y, DefaultHealthPoints, DefaultDefencePoints, team, DefaultRange)
        {
        }

        public int HealingPoints
        {
            get
            {
                return this.defaultHealPoints;
            }

            set
            {
                this.defaultHealPoints = value;
            }
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            return targetsList
                .Where(x => x.IsAlive)
                .Where(x => x.Team == this.Team)
                .Where(x => x.Id != this.Id)
                .OrderBy(x => x.Id)
                .FirstOrDefault();
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
            return string.Format("{0}, Healing: {1}", base.ToString(), this.HealingPoints);
        }
    }
}
