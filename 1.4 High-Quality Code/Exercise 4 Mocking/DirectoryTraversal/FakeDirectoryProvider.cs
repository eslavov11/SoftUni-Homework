namespace DirectoryTraversal
{
    using DirectoryTraversal.Interfaces
        ;
    public class FakeDirectoryProvider : IDirectoryPovider
    {
        public string[] GetDirectories(string currentDirectory)
        {
            return new [] { "C:\\Edi\\Programs\\RTCW", "C:\\Edi\\Programs\\Mass Effect"};
        }
    }
}
