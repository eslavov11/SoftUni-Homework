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

        public Mage(string id, int x, int y, string team) 
            : base(id, x, y, team, DefaultHealthPoints, DefaultDefencePoints, DefaultRange)
        {
        }

    }
}
