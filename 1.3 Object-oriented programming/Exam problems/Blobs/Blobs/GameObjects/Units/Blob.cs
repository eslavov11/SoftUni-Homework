using System.CodeDom;
using Blops.Exceptions;

namespace Blops.Models
{
    using Interfaces;

    public class Blob : IBlob
    {
        private const int MinimumDefaultHealthWhenPerformingAttack = 1;

        private readonly int InitialBlobHealth;
        private readonly int InitialBlobDamage;

        private string name;
        private int health;
        private int damage;

        public Blob(string name, int health, int damage, IBehavior behavior, IAttack attack)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
            this.Behavior = behavior;
            this.Attack = attack; 
            this.BehaviorIsTriggered = false;
            this.BehaviorTriggeredInBattle = false;
            this.InitialBlobHealth = health;
            this.InitialBlobDamage = damage;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new BlopException("Blop name cannot be empty!");
                }
                this.name = value;
            }
        }

        public int Damage
        {
            get { return this.damage; }
            set
            {
                if (value < 0)
                {
                    throw new BlopException("Blop damage cannot have a negative value");
                }
                this.damage = value;
            }
        }

        public int InitialDamage { get { return this.InitialBlobDamage; } }

        public int Health { get; set; }

        public int InitialHealth { get { return this.InitialBlobHealth; } }
        
        public IBehavior Behavior { get; }

        public void UpdateBehavior()
        {
            if (this.BehaviorShouldBeTriggered(this.Health, this.InitialHealth) && !this.BehaviorIsTriggered)
            {
                this.Behavior.Trigger(this);

                this.BehaviorIsTriggered = true;
            }
            else if (BehaviorIsTriggered)
            {
                this.Behavior.ApplyBehaviorTurn(this);
            }

        }

        public bool BehaviorIsTriggered { get; set; }

        public bool BehaviorTriggeredInBattle { get; set; }

        public IAttack Attack { get; }

        public void PerformAttack(IBlob targetBlob)
        {
            if (this.Health <= 0)
            {
                throw new AttackBlopException($"Cannot perform attack, blop {this.Name} is dead");
            }

            if (targetBlob.Health <= 0)
            {
               throw new AttackBlopException($"Cannot perform attack, blop {targetBlob.Name} is dead");
            }

            if (this.BehaviorShouldBeTriggered(CalculateHealthToSubstract(), this.InitialHealth) && 
                !this.BehaviorIsTriggered)
            {
                this.Behavior.Trigger(this);

                this.BehaviorIsTriggered = true;

                this.BehaviorTriggeredInBattle = true;
            }

            //if (BehaviorShouldBeTriggered(targetBlob.Health - (int)(this.Damage * this.Attack.AttackIncreaseRate),
            //    targetBlob.InitialHealth) &&
            //    !targetBlob.BehaviorIsTriggered)
            //{
            //    targetBlob.Behavior.Trigger(targetBlob);

            //    targetBlob.BehaviorIsTriggered = true;

            //   targetBlob.BehaviorTriggeredInBattle = true;
            //}

            targetBlob.Health -= (int)(this.Damage * this.Attack.AttackIncreaseRate);
            this.Health = CalculateHealthToSubstract();

            if (this.Health < MinimumDefaultHealthWhenPerformingAttack)
            {
                this.Health = MinimumDefaultHealthWhenPerformingAttack;
            }
            
            if (targetBlob.Health < 0)
            {
                targetBlob.Health = 0;
            }
        }

        private int CalculateHealthToSubstract()
        {
            int healthToSubtract = (int) (this.Health/this.Attack.HealthLossRate);
            return this.Health%2 == 0 ? healthToSubtract : healthToSubtract + 1;
        }

        private bool BehaviorShouldBeTriggered(int blopHealth, int blopInitHealth)
        {
            return blopHealth <= blopInitHealth / 2;
        }

        public override string ToString()
        {
            
            return 
                this.Health > 0 ?
                $"Blob {this.Name}: {this.Health} HP, {this.Damage} Damage" :
                $"Blob {this.Name} KILLED";
        }
    }
}
