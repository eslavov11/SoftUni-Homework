using System;
using System.Collections.Generic;
using Empires.Interfaces;

namespace Empires.Core
{
    public class EmpiresDatabase : IDatabase
    {
        public EmpiresDatabase()
        {
            //Todo IBUildings or Buildings??
            this.Buildings = new List<IBuilding>();
            this.Resources = new List<IResource>();
            this.Units = new List<IUnit>();
        }

        public ICollection<IBuilding> Buildings { get; }

        public ICollection<IResource> Resources { get; }

        public ICollection<IUnit> Units { get; set; } 
    }
}
