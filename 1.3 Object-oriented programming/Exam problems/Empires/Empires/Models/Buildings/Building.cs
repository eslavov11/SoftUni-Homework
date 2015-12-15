using Empires.Interfaces;

namespace Empires.Models.Buildings
{
    public abstract class Building : IBuilding
    {
        protected Building()
        {
            this.Turns = -1;
        }

        public int Turns { get; set; }

        public void Turn()
        {
            this.Turns++;
        }

        public abstract IUnit ProduceUnit();

        public abstract IResource ProduceResources();

        public override string ToString()
        {
            return "--{0}: {1} turns ({2} turns until {3}, {4} turns until {5})";
        }
    }
}
