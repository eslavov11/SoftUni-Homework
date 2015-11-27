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

        public Healer(string id, int x, int y, string team) 
            : base(id, x, y, team, DefaultHealthPoints, DefaultDefencePoints, DefaultRange)
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
    }
}
