using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empires.Models.Units
{
    public class Archer : Unit
    {
        private const int DefaultArcherAttackDamage = 7;
        private const int DefaultArcherHealth = 25;

        public Archer()
            : base(DefaultArcherHealth, DefaultArcherAttackDamage)
        {
            
        }

    }
}
