using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empires.Models.Units
{
    public class Swordsman : Unit
    {
        private const int DefaultSwordsmanAttackDamage = 13;
        private const int DefaultSwordsmanHealth = 40;

        public Swordsman()
            : base(DefaultSwordsmanHealth, DefaultSwordsmanAttackDamage)
        {

        }
    }
}
