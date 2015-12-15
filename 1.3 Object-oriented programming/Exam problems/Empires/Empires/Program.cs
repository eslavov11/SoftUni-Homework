using Empires.Core.Engines;
using Empires.Interfaces;

namespace Empires
{
    public class Program
    {
        static void Main(string[] args)
        {
            IEngine engine = new EmpireEngine();
            engine.Run();
        }
    }
}
