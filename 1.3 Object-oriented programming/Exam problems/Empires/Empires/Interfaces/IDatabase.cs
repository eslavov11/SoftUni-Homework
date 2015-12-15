using System.Collections.Generic;
using Empires.Models.Resources;

namespace Empires.Interfaces
{
    public interface IDatabase
    {
        ICollection<IBuilding> Buildings { get; }

        IDictionary<ResourceType, int> Resources { get; }

        ICollection<IUnit> Units { get; set; }
    }
}
