using System.Collections.Concurrent;

namespace Empires.Interfaces
{
    public interface IBuilding
    {
        int Turns { get; set; }

        void Turn();
        void ProduceUnit();
        void ProduceResources();
    }
}
