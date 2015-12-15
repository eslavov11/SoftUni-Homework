using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Interfaces;

namespace Empires.Models.Units
{
    public abstract class Unit : IUnit
    {
        protected Unit(int health, int attackDamage)
        {
            this.Health = health;
            this.AttackDamage = attackDamage;
        }

        public int Health { get; set; }

        public int AttackDamage { get; }
    }
}
