using System;
using FarmersCreed.Interfaces;

namespace FarmersCreed.Units
{
    public class Swine : Animal
    {
        private const int DefaultSwineHealth = 20;
        private const int DefaultSwineProductionQuantity = 1;

        public Swine(string id)
            : base(id, DefaultSwineHealth, DefaultSwineProductionQuantity)
        {
        }

        public override Product GetProduct()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Swine is dead!");
            }
            var product = new Food(this.Id + "Product", ProductType.PorkMeat, FoodType.Meat, this.ProductionQuantity,
                5);

            this.Health = 0;
            return product;
        }

        public override void Eat(IEdible food, int quantity)
        {
            switch (food.FoodType)
            {
                case FoodType.Meat:
                case FoodType.Organic:
                    this.Health += 2 * food.HealthEffect * quantity;
                    break;
                default:
                    break;
            }
        }

        public override void Starve()
        {
            base.Starve();
            base.Starve();
            base.Starve();
        }
    }
}
