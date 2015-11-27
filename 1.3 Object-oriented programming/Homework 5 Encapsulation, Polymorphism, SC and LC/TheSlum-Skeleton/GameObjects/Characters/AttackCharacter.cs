using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSlum.Interfaces;

namespace TheSlum.Characters
{
    public abstract class AttackCharacter : Character, IAttack
    {
        private int attack;

        public AttackCharacter(string id, int x, int y, string team, int health, int defence, int range) 
            : base(id, x, y, team, health, defence, range)
        {
            this.AttackPoints = attack;
        }

        public int AttackPoints
        {
            get
            {
                return this.attack;
            }

            set
            {
                this.attack = value;
            }
        }
    }
}
