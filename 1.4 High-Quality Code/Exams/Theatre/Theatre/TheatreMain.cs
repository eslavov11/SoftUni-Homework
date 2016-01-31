namespace Theatre
{
    using System.Globalization;
    using System.Threading;
    using Execution;

    public class TheatreMain
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");
            var theatreEngine = new TheatreEngine();
            theatreEngine.Run();
        }
    }
}
