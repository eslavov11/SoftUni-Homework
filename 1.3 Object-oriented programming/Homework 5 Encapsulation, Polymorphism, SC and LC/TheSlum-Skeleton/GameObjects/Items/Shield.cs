using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSlum.GameObjects.Items
{
    public class Shield : Item
    {
        private const int DefaultHealthEffect = 0;
        private const int DefaultDefenceEffect = 50;
        private const int DefaultAttackEffect = 0;

        public Shield(string id) 
            : base(id, DefaultHealthEffect, DefaultDefenceEffect, DefaultAttackEffect)
        {
        }
    }
}
