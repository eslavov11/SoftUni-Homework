using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSlum.GameObjects.Items
{
    public class Injection : Bonus
    {
        private const int DefaultHealthEffect = 200;
        private const int DefaultDefenseEffect = 0;
        private const int DefaultAttackEffect = 0;

        public Injection(string id)
            : base(id, DefaultHealthEffect, DefaultDefenseEffect, DefaultAttackEffect)
        {
            this.Countdown = 3;
        }
    }
}
