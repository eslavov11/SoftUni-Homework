using System.Collections.Concurrent;

namespace Empires.Interfaces
{
    public interface IBuilding
    {
        int Turns { get; set; }

        void Turn();
        IUnit ProduceUnit();
        IResource ProduceResources();
    }
}
