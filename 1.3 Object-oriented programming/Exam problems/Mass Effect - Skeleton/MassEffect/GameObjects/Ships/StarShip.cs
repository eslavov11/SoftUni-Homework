using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MassEffect.GameObjects.Enhancements;
using MassEffect.GameObjects.Locations;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Ships
{
    public abstract class Starship : IStarship
    {
        private readonly IList<Enhancement> enhancements;

        protected Starship(string name, int health, int shields, int damage, double fuel, StarSystem location)
        {
            this.Name = name;
            this.Health = health;
            this.Shields = shields;
            this.Damage = damage;
            this.Fuel = fuel;
            this.Location = location;
            this.enhancements = new List<Enhancement>();
        }

        public string Name { get; set; }

        public int Health { get; set; }

        public int Shields { get; set; }

        public int Damage { get; set; }

        public double Fuel { get; set; }

        public StarSystem Location { get; set; }

        public IEnumerable<Enhancement> Enhancements
        {
            get { return this.enhancements; }
            
        }

        public void AddEnhancement(Enhancement enhancement)
        {
            if (enhancement == null)
            {
                throw new ArgumentNullException("Enhancements cannot be null");
            }

            this.enhancements.Add(enhancement);

            this.Shields += enhancement.ShieldBonus;
            this.Damage += enhancement.DamageBonus;
            this.Fuel += enhancement.FuelBonus;
        }

        public abstract IProjectile ProduceAttack();

        public virtual void RespondToAttack(IProjectile attack)
        {
            attack.Hit(this);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"--{this.Name} - {this.GetType().Name}");

            if (this.Health <= 0)
            {
                result.Append("(Destroyed)");
            }
            else
            {
                result.AppendLine($"-Location: {this.Location.Name}");
                result.AppendLine($"-Health: {this.Health}");
                result.AppendLine($"-Shields: {this.Shields}");
                result.AppendLine($"-Damage: {this.Damage}");
                result.AppendLine($"-Fuel: {$"{this.Fuel:F1}"}");

                string enhancementsOutput = "N/A";
                if (this.Enhancements.Any())
                {
                    enhancementsOutput = string.Join(", ", this.Enhancements);
                }
                result.Append($"-Enhancements: {enhancementsOutput}");
            }
            return result.ToString();
        }
    }
}
