namespace Skyrim.Units
{
    using System.Collections.Generic;

    using Skyrim.Items;

    public class Warrior : Unit
    {
        public Warrior(string name, int attackPoints, int healthPoints) 
            : base(name, attackPoints, healthPoints)
        {
            this.Inventory = new List<Weapon>();
        }

        public IList<Weapon> Inventory { get; private set; } 
    }
}
