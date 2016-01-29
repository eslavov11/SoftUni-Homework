namespace Matrix
{
    using Core;
    using Interfaces;

    public class MatrixMain
    {
        public static void Main(string[] args)
        {
            IEngine engine = new MatrixEngine();
            engine.Run();
        }
    }
}
