namespace FarmersCreed.Units
{
    using System;

    public abstract class Plant : FarmUnit
    {
        private int growTime;
        private bool hasGrown;

        protected Plant(string id, int health, int productionQuantity, int growTime)
            : base(id, health, productionQuantity)
        {
            this.GrowTime = growTime;
        }

        public bool HasGrown
        {
            get { return growTime == 0; }
        }

        public int GrowTime
        {
            get { return this.growTime; }
            set {
                if (value < 0)
                {
                    throw new ArgumentException("Growing time cannot be negative!");
                }
                this.growTime = value;
            }
        }

        public virtual void Water()
        {
            base.Health += 2;
        }

        public virtual void Wither()
        {
            base.Health--;
        }

        public virtual void Grow()
        {
            this.GrowTime--;
        }

        public abstract override Product GetProduct();

        public override string ToString()
        {
            string result = base.ToString();
            if (base.IsAlive)
            {
                result += ", Grown: " + (this.HasGrown ? "Yes" : "No");
            }
            return result;
        }
    }
}
