﻿using System;

namespace Battleships.Ships
{
    public abstract class Ship
    {
        private double lengthInMeters;
        private string name;
        private double volume;

        protected Ship(string name, double lengthInMeters, double volume)
        {
            this.Name = name;
            this.LengthInMeters = lengthInMeters;
            this.Volume = volume;
        }

        //public bool IsBattleship { get; set; }

        public bool IsDestroyed { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "Name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public double LengthInMeters
        {
            get
            {
                return this.lengthInMeters;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The length of a ship cannot be negative.");
                }

                this.lengthInMeters = value;
            }
        }

        public double Volume
        {
            get
            {
                return this.volume;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The volume of a ship cannot be negative.");
                }

                this.volume = value;
            }
        }
    }
}
