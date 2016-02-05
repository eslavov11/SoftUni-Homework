namespace mUnit.Sandbox
{
    using System.Reflection;
    using Core.Logic;

    public class SandboxMain
    {
        private static readonly string AssemblyPath = Assembly.GetExecutingAssembly().Location;

        static void Main()
        {
            var engine = new Engine(AssemblyPath, new ConsoleWriter());
            engine.Run();
        }
    }
}
