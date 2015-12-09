using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Projectiles
{
    public class Laser : Projectile
    {
        public Laser(int damage) 
            : base(damage)
        {
        }

        public override void Hit(IStarship ship)
        {
            if (this.Damage > ship.Shields)
            {
                ship.Health -= this.Damage - ship.Shields;
                ship.Shields = 0;
            }
            else
            {
                ship.Shields -= this.Damage;
            }
        }
    }
}
