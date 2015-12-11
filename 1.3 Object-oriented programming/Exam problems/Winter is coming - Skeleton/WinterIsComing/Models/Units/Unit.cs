using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Contracts;

namespace WinterIsComing.Models.Units
{
    public abstract class Unit : IUnit
    {
        protected Unit(string name, int x, int y, int range, int attack, int health, int defence, int energy)
        {
            this.X = x;
            this.Y = y;
            this.Name = name;
            this.Range = range;
            this.AttackPoints = attack;
            this.HealthPoints = health;
            this.DefensePoints = defence;
            this.EnergyPoints = energy;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public string Name { get; }

        public int Range { get; }

        public int AttackPoints { get; set; }

        public int HealthPoints { get; set; }

        public int DefensePoints { get; set; }

        public int EnergyPoints { get; set; }

        public abstract ICombatHandler CombatHandler { get; }

        public override string ToString()
        {
            if (this.HealthPoints > 0)
            {
                return $">{this.Name} - {this.GetType().Name} at ({this.X},{this.Y})" + Environment.NewLine +
                       $"-Health points = {this.HealthPoints}" + Environment.NewLine +
                       $"-Attack points = {this.AttackPoints}" + Environment.NewLine +
                       $"-Defense points = {this.DefensePoints}" + Environment.NewLine +
                       $"-Energy points = {this.EnergyPoints}" + Environment.NewLine +
                       $"-Range = {this.Range}";
            }
            else
            {
                return $">{this.Name} - {this.GetType().Name} at ({this.X},{this.Y})" + Environment.NewLine +
                "(Dead)";
            }
        }
    }
}
