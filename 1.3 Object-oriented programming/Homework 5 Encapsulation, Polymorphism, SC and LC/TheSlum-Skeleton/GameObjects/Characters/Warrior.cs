using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSlum.Characters
{
    class Warrior : AttackCharacter
    {
        private const int DefaultHealthPoints = 200;
        private const int DefaultDefencePoints = 100;
        private const int DefaultRange = 2;
        private const int DefaultAttackPoints = 150;

        public Warrior(string id, int x, int y, string team) 
            : base(id, x, y, team, DefaultHealthPoints, DefaultDefencePoints, DefaultRange)
        {
        }

    }
}
