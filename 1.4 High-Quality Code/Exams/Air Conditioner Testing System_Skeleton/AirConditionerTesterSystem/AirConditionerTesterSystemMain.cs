namespace AirConditionerTesterSystem
{
    using AirConditionerTesterSystem.Execution;
    using AirConditionerTesterSystem.UI;

    public class AirConditionerTesterSystemMain
    {
        public static void Main()
        {
            var engine = new Engine(new ConsoleUserInterface());
            engine.Run();
        }
    }
}
