using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSlum.GameObjects.Items
{
    public class Axe : Item
    {
        private const int DefaultHealthEffect = 0;
        private const int DefaultDefenceEffect = 0;
        private const int DefaultAttackEffect = 75;

        public Axe(string id) 
            : base(id, DefaultHealthEffect, DefaultDefenceEffect, DefaultAttackEffect)
        {
        }
    }
}
