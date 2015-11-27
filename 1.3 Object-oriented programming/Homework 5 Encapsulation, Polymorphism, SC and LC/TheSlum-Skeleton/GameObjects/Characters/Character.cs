using System;

namespace TheSlum.Characters
{
    public abstract class Character : GameObject
    {
        private int health;
        private int defence;
        private int range;

        public Character(string id, int x, int y, string team, int health, int defence, int range)
            : base (id)
        {
            this.X = x;
            this.Y = y;
            this.Team = team;
            this.Health = health;
            this.Defence = defence;
            this.Range = range;
        }
        
        public int X { get; set; }

        public int Y { get; set; }

        public string Team { get; set; }

        public int Health
        {
            get
            {
                return this.health;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid input");
                }
                this.health = value;
            }
        }

        public int Defence
        {
            get
            {
                return this.defence;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid input");
                }
                this.defence = value;
            }
        }

        public int Range
        {
            get
            {
                return this.range;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid input");
                }
                this.range = value;
            }
        }
    }
}
