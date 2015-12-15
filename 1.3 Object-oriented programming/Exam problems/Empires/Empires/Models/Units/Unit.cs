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
        public int Health { get; set; }

        public int AttackDamage { get; }
    }
}
