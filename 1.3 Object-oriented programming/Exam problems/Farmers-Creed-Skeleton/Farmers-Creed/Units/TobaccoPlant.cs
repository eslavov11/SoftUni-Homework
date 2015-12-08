using System;
using FarmersCreed.Units;
using Microsoft.SqlServer.Server;

namespace FarmersCreed
{
    public class TobaccoPlant : Plant
    {
        private const int DefaultTobaccoHealth = 15;
        private const int DefaultTobaccoGrowTime = 4;
        private const int DefaultTobaccoProductionQuantity = 10;
        public TobaccoPlant(string id)
            : base(id, DefaultTobaccoHealth, DefaultTobaccoProductionQuantity, DefaultTobaccoGrowTime)
        {
        }

        public override void Grow()
        {
            base.Grow();
            base.Grow();
        }

        public override Product GetProduct()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Tobacco is dead!");
            }

            if (!this.HasGrown)
            {
                throw new InvalidOperationException("Tobacco is still growing!");
            }

            var product = new Product(this.Id + "Product", ProductType.Tobacco, this.ProductionQuantity);

            return product;
        }
    }
}
