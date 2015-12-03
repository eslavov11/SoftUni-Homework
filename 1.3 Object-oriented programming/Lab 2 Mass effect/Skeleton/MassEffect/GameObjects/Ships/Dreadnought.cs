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
    public class Dreadnought : Starship
    {
        private const int DefaultHealth = 200;
        private const int DefaultShields = 300;
        private const int DefaultDamage = 150;
        private const int DefaultFuel = 700;

        public Dreadnought(string name, StarSystem location)
            : base(name, DefaultHealth, DefaultShields, DefaultDamage, DefaultFuel, location)
        {
        }

        public override void RespondToAttack(IProjectile attack)
        {
            this.Shields += 50;

            base.RespondToAttack(attack);

            this.Shields -= 50;
        }

        public override IProjectile ProduceAttack()
        {
            return new Laser(this.Damage + this.Shields / 2);
        }

    }
}
