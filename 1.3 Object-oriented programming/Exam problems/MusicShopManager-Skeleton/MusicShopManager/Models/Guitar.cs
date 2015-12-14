using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicShopManager.Interfaces;

namespace MusicShop.Models
{
    public abstract class Guitar : Instrument, IGuitar
    {
        private string body;
        private string fingerboardWood;

        protected Guitar(string make, string model, decimal price,
            string color, string bodyWood, string fingerBodyWood)
            : base(make, model, price, color)
        {
            this.BodyWood = bodyWood;
            this.FingerboardWood = fingerBodyWood;
        }

        public string BodyWood
        {
            get { return this.body; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The body wood is required.");
                }
                this.body = value;

            }
        }

        public string FingerboardWood
        {
            get { return this.fingerboardWood; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The fingerboard wood is required.");
                }
                this.fingerboardWood = value;

            }
        }

        public int NumberOfStrings { get; protected set; }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine +
                $"Strings: {this.NumberOfStrings}" + Environment.NewLine +
                   $"Body wood: {this.BodyWood}" + Environment.NewLine +
                   $"Fingerboard wood: {this.FingerboardWood}";

        }
    }
}
