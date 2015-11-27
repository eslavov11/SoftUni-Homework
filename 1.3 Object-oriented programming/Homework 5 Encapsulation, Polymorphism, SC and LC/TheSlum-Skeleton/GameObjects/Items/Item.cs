using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSlum.Interfaces;

namespace TheSlum.GameObjects.Items
{
    public class Item : GameObject
    {
        private const int HealthEffect = 0;
        private int defenceEffect;
        private int attackEffect;

        public Item(string id)
            : base(id)
        {
        }

        public int DefenceEffect
        {
            get
            {
                return this.defenceEffect;
            }

            set
            {
                this.defenceEffect = value;
            }
        }

        public int AttackEffect
        {
            get
            {
                return this.attackEffect;
            }

            set
            {
                this.attackEffect = value;
            }
        }


    }
}
