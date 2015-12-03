using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Projectiles
{
    public abstract class Projectile : IProjectile
    {
        protected Projectile(int damage)
        {
            this.Damage = damage;
        }

        public int Damage { get; set; }

        public abstract void Hit(IStarship ship);
    }
}
