namespace BangaloreUniversityLearningSystem.Interfaces
{
    using System.Collections.Generic;

    public interface IRoute
    {
        string ControllerName { get; }

        string ActionName { get; }

        IDictionary<string, string> Parameters { get; }
    }
}