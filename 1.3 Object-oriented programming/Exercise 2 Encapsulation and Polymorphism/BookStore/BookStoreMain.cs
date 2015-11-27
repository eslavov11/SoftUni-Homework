namespace BookStore
{
    using Interfaces;
    using Engine;
    using UI;

    public class BookStoreMain
    {
        public static void Main()
        {
            IInputHandler consoleHandler = new ConsoleInputHandler();
            IRenderer consoleRenderer = new ConsoleRenderer();
            BookStoreEngine engine = new BookStoreEngine(consoleRenderer, consoleHandler);

            engine.Run();
        }
    }
}
