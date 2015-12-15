using Empires.Interfaces;

namespace Empires.Models.Buildings
{
    public abstract class Building : IBuilding
    {
        public int Turns { get; set; }

        public void Turn()
        {
            this.Turns++;
            this.ProduceResources();
            this.ProduceUnit();
        }

        public abstract void ProduceUnit();

        public abstract void ProduceResources();
    }
}
