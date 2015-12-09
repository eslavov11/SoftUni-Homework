using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassEffect.GameObjects.Locations;
using MassEffect.GameObjects.Projectiles;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Ships
{
    public class Cruiser : Starship
    {
        private const int DefaultHealth = 100;
        private const int DefaultShields = 100;
        private const int DefaultDamage = 50;
        private const int DefaultFuel = 300;

        public Cruiser(string name, StarSystem location) 
            : base(name, DefaultHealth, DefaultShields, DefaultDamage, DefaultFuel, location)
        {
        }

        public override IProjectile ProduceAttack()
        {
            return new PenetrationShell(this.Damage);
        }
    }
}
