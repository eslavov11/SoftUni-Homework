using System;
using FarmersCreed.Interfaces;

namespace FarmersCreed.Units
{
    public class CherryTree : FoodPlant
    {
        private const int DefaultCherryTreeHealth = 14;
        private const int DefaultCherryTreeGrowTime = 3;
        private const int DefaultCherryTreeProductionQuantity = 4;

        public CherryTree(string id)
            : base(id, DefaultCherryTreeHealth, DefaultCherryTreeProductionQuantity, DefaultCherryTreeGrowTime)
        {
            
        }

        public override Product GetProduct()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Cherry tree is dead!");
            }

            var product = new Food(this.Id + "Product", ProductType.Cherry, FoodType.Organic, this.ProductionQuantity,
                2);
            
            return product;
        }
    }
}
