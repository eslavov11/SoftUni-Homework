namespace DirectoryTraversal
{
    using System.Collections.Generic;
    using System.IO;
    using Interfaces;

    public class DirectoryTraverser
    {
        public DirectoryTraverser(string directory,
            IDirectoryPovider directoryPovider)
        {
            this.CurrentDirectory = directory;
            this.DirectoryPovider = directoryPovider;
        }

        public string CurrentDirectory { get; set; }

        public IDirectoryPovider DirectoryPovider { get; set; }

        public IEnumerable<string> GetChildDirectories()
        {
            var directories = DirectoryPovider.GetDirectories(this.CurrentDirectory);

            var directoryNames = new List<string>(directories.Length);
            foreach (var directory in directories)
            {
                int lastBackSlash = directory.LastIndexOf("\\");
                string directoryName = directory.Substring(lastBackSlash + 1);

                directoryNames.Add(directoryName);
            }

            directoryNames.Sort();

            return directoryNames;
        }
    }
}
