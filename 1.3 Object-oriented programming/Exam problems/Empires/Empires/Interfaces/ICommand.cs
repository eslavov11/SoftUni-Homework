using System.Collections.Generic;

namespace Empires.Interfaces
{
    public interface ICommand
    {
        string Name { get; }

        IList<string> Parameters { get; } 
    }
}
