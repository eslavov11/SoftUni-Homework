using System;
using System.Collections.Generic;
using Empires.Interfaces;
using Empires.Models.Resources;

namespace Empires.Core
{
    public class EmpiresDatabase : IDatabase
    {
        public EmpiresDatabase()
        {
            //Todo IBUildings or Buildings??
            this.Buildings = new List<IBuilding>();
            this.Resources = new Dictionary<ResourceType, int>
            {
                { ResourceType.Gold, 0},
                { ResourceType.Steel, 0}
            };
            this.Units = new List<IUnit>();
        }

        public ICollection<IBuilding> Buildings { get; }

        public IDictionary<ResourceType, int> Resources { get; }

        public ICollection<IUnit> Units { get; set; } 
    }
}
