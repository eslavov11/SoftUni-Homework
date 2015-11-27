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

        public AttackCharacter(string id, int x, int y, int health, int defence, Team team, int range) 
            : base(id, x, y, health, defence, team, range)
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
