using System;
using MusicShopManager.Interfaces;

namespace MusicShop.Models
{
    public class Microphone : Article, IMicrophone
    {
        public Microphone(string make, string model, decimal price, bool hasCable) 
            : base(make, model, price)
        {
            this.HasCable = hasCable;
        }

        public bool HasCable { get; private set; }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + "Cable: " + (this.HasCable ? "yes" : "no");
        }
    }
}
