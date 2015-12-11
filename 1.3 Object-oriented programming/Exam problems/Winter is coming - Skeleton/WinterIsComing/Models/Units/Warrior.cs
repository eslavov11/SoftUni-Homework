using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Contracts;
using WinterIsComing.Models.CombatHandlers;

namespace WinterIsComing.Models.Units
{
    public class Warrior : Unit
    {
        private const int DefaultWarriorAttackPoints = 120;
        private const int DefaultWarriorHealthPoints = 180;
        private const int DefaultWarriorDefencePoints = 70;
        private const int DefaultWarriorEnergyPoints = 60;
        private const int DefaultWarriorRange = 1;

        public Warrior(string name, int x, int y)
            : base(name, x, y,
                DefaultWarriorRange,
                DefaultWarriorAttackPoints,
                DefaultWarriorHealthPoints,
                DefaultWarriorDefencePoints,
                DefaultWarriorEnergyPoints)
        {
            
        }

        public override ICombatHandler CombatHandler
        {
            get
            {
                return new WarriorCombatHandler(this);
            }
        }
    }
}
