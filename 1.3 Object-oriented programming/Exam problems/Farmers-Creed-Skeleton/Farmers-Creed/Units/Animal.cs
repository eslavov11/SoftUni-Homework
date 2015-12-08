namespace FarmersCreed.Units
{
    using System;
    using FarmersCreed.Interfaces;

    public abstract class Animal : FarmUnit
    {
        protected Animal(string id, int health, int productionQuantity)
            : base(id, health, productionQuantity)
        {
        }

        public virtual void Eat(IEdible food, int quantity)
        {
            food.Quantity -= quantity;
        }

        public virtual void Starve()
        {
            base.Health--;
        }


        public abstract override Product GetProduct();
    }
}
