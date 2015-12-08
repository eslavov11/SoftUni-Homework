using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersCreed.Units
{
    public abstract class FoodPlant : Plant
    {
        protected FoodPlant(string id, int health, int productionQuantity, int growTime)
        : base(id, health, productionQuantity, growTime)
        {
        }

        public override void Water()
        {
            base.Health++;
        }

        public override void Wither()
        {
            base.Wither();
            base.Wither();
        }
    }
}
