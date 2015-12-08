using System;
using FarmersCreed.Interfaces;

namespace FarmersCreed.Units
{
    public class Cow : Animal
    {
        private const int DefaultCowHealth = 15;
        private const int DefaultCowProductionQuantity = 6;

        public Cow(string id) 
            : base(id, DefaultCowHealth, DefaultCowProductionQuantity)
        {
        }

        public override Product GetProduct()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Cow is dead!");
            }
            
            var product = new Food(this.Id + "Product", ProductType.Milk, FoodType.Organic, this.ProductionQuantity,
                4);

            this.Health -= 2;
            return product;
        }

        public override void Eat(IEdible food, int quantity)
        {
            switch (food.FoodType)
            {
                case FoodType.Meat:
                    this.Health -= food.HealthEffect * quantity;
                    break;
                case FoodType.Organic:
                    this.Health += food.HealthEffect * quantity;
                    break;
                default:
                    break;
            }
        }
    }   
}
