using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Contracts;
using WinterIsComing.Models.CombatHandlers;

namespace WinterIsComing.Models.Units
{
    public class Mage : Unit
    {
        private const int DefaultMageAttackPoints = 80;
        private const int DefaultMageHealthPoints = 80;
        private const int DefaultMageDefencePoints = 40;
        private const int DefaultMageEnergyPoints = 120;
        private const int DefaultMageRange = 2;

        public Mage(string name, int x, int y)
            : base(name, x, y,
                  DefaultMageRange,
                  DefaultMageAttackPoints,
                  DefaultMageHealthPoints,
                  DefaultMageDefencePoints,
                  DefaultMageEnergyPoints)
        {
        }

        public override ICombatHandler CombatHandler
        {
            get
            {
                return new MageCombatHandler(this);
            }
        }
    }
}
