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
    public class Frigate : Starship
    {
        private int projectilesFired;

        private const int DefaultHealth = 60;
        private const int DefaultShields = 50;
        private const int DefaultDamage = 30;
        private const int DefaultFuel = 220;

        public Frigate(string name, StarSystem location) 
            : base(name, DefaultHealth, DefaultShields, DefaultDamage, DefaultFuel, location)
        {
        }

        public override IProjectile ProduceAttack()
        {
            var shell = new ShieldReaver(this.Damage);
            if (shell != null)
            {
                this.projectilesFired++;
            }
            return shell;
        }

        public override string ToString()
        {
            string result = base.ToString();

            if (this.Health > 0)
            {
                result += Environment.NewLine + $"-Projectiles fired: {this.projectilesFired}";
            }

            return result;
        }
    }
}
