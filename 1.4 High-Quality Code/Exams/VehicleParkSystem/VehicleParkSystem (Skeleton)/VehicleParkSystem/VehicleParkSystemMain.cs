namespace VehicleParkSystem
{
    using System.Globalization;
    using System.Threading;

    using VehicleParkSystem.Execution;

    public class VehicleParkSystemMain
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var engine = new VehicleParkSystemEngine();
            engine.Run();
        }
    }
}