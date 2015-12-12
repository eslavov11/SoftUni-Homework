using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Contracts;
using WinterIsComing.Models.CombatHandlers;

namespace WinterIsComing.Models.Units
{
    public class IceGiant : Unit
    {
        private const int DefaultIceGiantAttackPoints = 150;
        private const int DefaultIceGiantHealthPoints = 300;
        private const int DefaultIceGiantDefencePoints = 60;
        private const int DefaultIceGiantEnergyPoints = 50;
        private const int DefaultIceGiantRange = 1;

        public IceGiant(string name, int x, int y)
            : base(name, x, y,
                  DefaultIceGiantRange,
                  DefaultIceGiantAttackPoints,
                  DefaultIceGiantHealthPoints,
                  DefaultIceGiantDefencePoints,
                  DefaultIceGiantEnergyPoints)
        {
        }

        public override ICombatHandler CombatHandler
        {
            get
            {
                return new IceGiantCombatHandler(this);
            }
        }
    }
}
