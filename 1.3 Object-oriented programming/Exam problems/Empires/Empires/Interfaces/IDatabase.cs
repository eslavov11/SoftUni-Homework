using System.Collections.Generic;

namespace Empires.Interfaces
{
    public interface IDatabase
    {
        ICollection<IBuilding> Buildings { get; }

        ICollection<IResource> Resources { get; }

        ICollection<IUnit> Units { get; set; }
    }
}
