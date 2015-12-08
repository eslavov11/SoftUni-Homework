using FarmersCreed.Interfaces;

namespace FarmersCreed.Units
{
    using System;

    public abstract class FarmUnit : GameObject, IProductProduceable
    {
        private int health;
        private int productionQuantity;

        protected FarmUnit(string id, int health, int productionQuantity)
            : base(id)
        {
            this.Health = health;
            this.ProductionQuantity = productionQuantity;
        }

        public int Health
        {
            get { return this.health; }
            set {
                if (value < 0)
                {
                  //  this.IsAlive = false;
                    //throw new ArgumentException("Health cannot be a negative number!");
                }
                this.health = value;
            }
        }

        public bool IsAlive
        {
            get { return this.Health > 0; }
        }

        public int ProductionQuantity
        {
            get { return this.productionQuantity; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Production quantity cannot be a negative number!");
                }
                this.productionQuantity = value;
            }
        }

        public abstract Product GetProduct();

        public override string ToString()
        {
            return $"{base.ToString()}{(this.IsAlive ? $", Health: {this.Health}" : ", DEAD")}";
        }
    }
}
